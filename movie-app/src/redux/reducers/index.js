import { combineReducers } from "redux";
import { movieReducer } from './movieReducer';

const reducers = combineReducers({
    allMovies: movieReducer,
    allTVshows: movieReducer,
});

export default reducers;