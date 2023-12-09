import { combineReducers } from "redux";
import authReducer from "./auth/authReducer";
import newsReducer from "./news/newsReducer";

const rootReducer = combineReducers({ auth: authReducer, news: newsReducer });

export default rootReducer;
