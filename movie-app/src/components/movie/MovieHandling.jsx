import React, { useEffect, useRef, useState } from 'react'
import axios from 'axios'
import { useDispatch, useSelector } from 'react-redux'
import { searchMovies, setMovies } from '../../redux/actions/moviesActions'
import MovieList from './MovieList'
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import CardGroup from 'react-bootstrap/CardGroup'
import Row from 'react-bootstrap/Row'
import InputGroup from 'react-bootstrap/InputGroup'
import Button from 'react-bootstrap/Button'
import Spinner from 'react-bootstrap/Spinner'

function Main() {
    const [isMovie, setIsMovie] = useState(true)
    const loading = useSelector((state) => state.allMovies.loading);
    const movies = useSelector((state) => state.allMovies.movies);
    const [page, setPage] = useState(1)
    const dispatch = useDispatch()

    const fetchMovies = async (loadmore, page) => {
        dispatch({ type: 'SET_LOADING', payload: true })
        const res = await axios
            .get(`https://localhost:44343/api/Movie/search/${isMovie}?page=${page}`)
            .catch((err) => {
                console.log('Error occured', err)
            })

        dispatch({ type: 'SET_LOADING', payload: false })
        if (loadmore) {
            dispatch(setMovies([...movies, ...res.data]))
        } else {
            dispatch(setMovies(res.data))
        }
        console.log("Res: ", res.data);
    }



    const ToggleMovie = (value) => {
        if (value == 'movies') {
            setPage(1)
            setIsMovie(true)
        } else {
            setPage(1)
            setIsMovie(false)
        }
    }

    const searchNews = async (e) => {
        // Check if entered value length is at least two chars long
        if (e?.length && e.length <= 2) {
            return
        }
        dispatch({ type: 'SET_LOADING', payload: true })
        const res = await axios
            .get(`https://localhost:44343/api/Movie/search/${isMovie}?searchValue=${e}`)
            .catch((err) => {
                console.log('Error occured', err)
            })
        if (res.status === 200) {
            dispatch(setMovies(res.data))
        }
        dispatch({ type: 'SET_LOADING', payload: false })
    }


    useEffect(() => {
        fetchMovies(false, 1)
    }, [isMovie])

    return (
        <div>

            {/* Search section */}
            <div className="form-wrapper form-search mb-4">
                <form onSubmit={searchNews}>
                    <InputGroup className="mb-3 search">
                        <input
                            type="text"
                            onChange={(e) => {
                                searchNews(e.target.value)
                            }}
                            className="form-control"
                            placeholder="Search for something"
                            autoComplete="off"
                        />
                    </InputGroup>
                </form>
            </div>


            {/* Tabs section*/}
            <Tabs defaultActiveKey="movies" className="mb-3" onSelect={ToggleMovie}>
                <Tab eventKey="movies" title="Movies">
                    {(movies.length > 0 ?
                        <Row className="row-cols-2  row-cols-md-3 row-cols-lg-5 row-cols-xl-5">
                            <MovieList key={1} />
                        </Row>
                        :
                        <div className="no-movies text-center"><h2>No movies found!</h2></div>)}

                    {(movies.length >= 10) ? <div className="load-more-wrapper">
                        <Button variant="secondary" onClick={() => { setPage(page + 1); fetchMovies(true, page + 1) }}>
                            Load more
                        </Button>

                    </div>
                        :
                        ""
                    }


                </Tab>
                <Tab eventKey="tvshow" title="TV Show" >

                    {(movies.length > 0 ?
                        <Row className="row-cols-2  row-cols-md-3 row-cols-lg-5 row-cols-xl-5">
                            <MovieList key={2} />
                        </Row>
                        :
                        <div className="no-movies text-center"><h2>No TV shows found!</h2></div>)}

                    {/* Load more */}
                    {(movies.length >= 10) ? <div className="load-more-wrapper">
                        <Button variant="secondary" onClick={() => { setPage(page + 1); fetchMovies(true, page + 1) }}>
                            Load more
                        </Button>
                    </div>
                        :
                        " "}




                </Tab>
            </Tabs>

        </div>

    )
}

export default Main
