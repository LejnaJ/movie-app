import { ActionTypes } from "../constants/actionTypes";

const initialState = {
    movies: [],
    tvshows: [],
    value: '',
    searchTerm: "",
    loading: false
}

export const movieReducer = (state = initialState, { type, payload }) => {
    switch (type) {
        case "SET_LOADING":
            return {...state, loading: payload }
        case ActionTypes.SET_MOVIES:
            return {...state, movies: [...payload] };
        case ActionTypes.SEARCH_MOVIES:
            return {...state, movies: payload };

        default:
            return state;
    }
}