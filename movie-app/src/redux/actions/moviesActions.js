import { ActionTypes } from "../constants/actionTypes";
export const setMovies = (movies) => {
    return {
        type: ActionTypes.SET_MOVIES,
        payload: movies,
    }
}
export const setTVShows = (movies) => {
    return {
        type: ActionTypes.SET_TVSHOWS,
        payload: movies,
    }
}


export const searchMovies = (movies) => {
    return {
        type: ActionTypes.SEARCH_MOVIES,
        payload: movies,
    }
}