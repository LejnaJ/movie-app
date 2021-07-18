import React from "react";
import { useSelector } from "react-redux";
import defaultPic from "../../assets/img/default.jpg"
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import ReactStars from "react-rating-stars-component";
const MovieList = () => {

  const movies = useSelector((state) => state.allMovies.movies);
  const renderList = movies.map((movie, i) => {
    const { movieName, movieDescription, imgUrl, releaseDate, imgAlt, averageRating } = movie;

    let avgRating = averageRating / 2.0;
    const imageErr = (e) => {
      e.target.src = defaultPic;
    }
    return (
      <Col className="col-card" key={movieName}>
        <Card style={{ height: '100%' }} >
          <Card.Img variant="top" onError={imageErr} src={(imgUrl) ? imgUrl : defaultPic} alt={imgAlt} />
          <Card.Body>
            <div className="date">{new Date(releaseDate).toLocaleDateString('en-us',{ year: 'numeric'})}</div>
            <div className="rating"><ReactStars
              count={5}
              size={24}
              activeColor="#ffd700"
              isHalf= {true}
              edit={false}
              value = {avgRating}
            />
            <div className="avg-rating">{avgRating}</div>
            </div>
            <Card.Title>{movieName}</Card.Title>
            <Card.Text>{movieDescription}
            </Card.Text>
       
          </Card.Body>
        </Card>
      </Col>

    )

  })



  return (
    <>{renderList}</>

    // <h4>Test</h4>
  );

};
export default MovieList;