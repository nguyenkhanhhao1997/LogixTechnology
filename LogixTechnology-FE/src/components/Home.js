import React, { useEffect, useState } from "react";
import { makeStyles } from "@material-ui/core/styles";
import { Redirect } from "react-router-dom";
import callApi from "../api/apiService";
import {
  Card,
  CardHeader,
  CardMedia,
  CardActions,
  IconButton,
} from "@material-ui/core";
import { ThumbDown, ThumbUp } from "@material-ui/icons";
import logo from "../logo.svg";

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
    marginTop: 20,
  },
  card: {
    marginTop: "20px",
  },
}));

const Home = () => {
  const classes = useStyles();
  const [userId, setUserId] = useState(sessionStorage.getItem("userId"));
  const [token, setToken] = useState(sessionStorage.getItem("token"));
  const [login, setLogin] = useState(sessionStorage.getItem("login"));
  const [movies, setMovies] = useState({});
  const [numberSkip, setNumberSkip] = useState(0);

  useEffect(() => {
    if (token !== null && userId !== null) {
      loadMoreMovie();
    }
    window.addEventListener("scroll", handleScroll);
  }, []);

  const loadMoreMovie = () => {
    //get movies data
    let data = {
      skip: numberSkip,
      userId: userId,
    };
    console.log(data);
    let headers = { Authorization: `Bearer ${token}` };
    callApi(`home/getall`, "POST", data, headers).then((item) => {
      setMovies((movies) => [...movies, ...item.data]);
      setNumberSkip(numberSkip + 5);
    });
  };

  const handleScroll = (e) => {
    const scrollHeight = e.target.documentElement.scrollHeight;
    const currentHeight = Math.ceil(
      e.target.documentElement.scrollTop + window.innerHeight
    );
    if (currentHeight + 1 >= scrollHeight) {
      loadMoreMovie();
    }
  };

  const handleUserReact = (movieId, userReact, action) => {
    let act = 0;
    if (userReact !== action) {
      act = action;
    }

    let isLike = false;
    if (action === 1 && act === 1) {
      isLike = true;
    }

    let data = {
      movieId: movieId,
      userId: userId,
      action: act,
    };
    let headers = { Authorization: `Bearer ${token}` };

    callApi(`home/reactmovie`, "POST", data, headers).then((item) => {
      if (item.data === "success") {
        let newList = movies.map((item) => {
          if (item.movieId === movieId) {
            item.userReact = act;
            if (isLike) {
              item.likeNumber = item.likeNumber + 1;
            } else {
              item.likeNumber = item.likeNumber - 1;
            }
          }
          return item;
        });
        setMovies(newList);
      } else {
        alert("Something went wrong");
      }
    });
  };

  if (login === null || login === "false") {
    return <Redirect to={{ pathname: "/login" }} />;
  }

  return (
    <div className={classes.root}>
      {movies.length > 0 &&
        movies.map((movie) => {
          return (
            <Card
              className={classes.card}
              sx={{ maxWidth: 345 }}
              key={movie.movieId}
            >
              <CardHeader title={movie.title} />
              <CardMedia
                component="img"
                height="250"
                image={logo}
                alt="Movie Image"
              />
              <CardActions disableSpacing>
                <h4>Like: {movie.likeNumber}</h4>
                <IconButton
                  onClick={() =>
                    handleUserReact(movie.movieId, movie.userReact, 1)
                  }
                >
                  {movie.userReact === 1 && <ThumbUp color="primary" />}
                  {movie.userReact !== 1 && <ThumbUp />}
                </IconButton>
                <IconButton
                  aria-label="share"
                  onClick={() =>
                    handleUserReact(movie.movieId, movie.userReact, 2)
                  }
                >
                  {movie.userReact === 2 && <ThumbDown color="primary" />}
                  {movie.userReact !== 2 && <ThumbDown />}
                </IconButton>
              </CardActions>
            </Card>
          );
        })}
    </div>
  );
};

export default Home;
