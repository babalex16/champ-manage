import { combineReducers } from "redux";
import {signedUserReducer} from "./signedUserReducer";

const rootReducer = combineReducers({user: signedUserReducer});

export default rootReducer;