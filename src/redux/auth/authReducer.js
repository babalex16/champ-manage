const initialState = {
  error: null,
  isAuthenticated: false,
};

const authReducer = (state = initialState, action) => {
  switch (action.type) {
    case 'LOGIN_SUCCESS':
      return {
        ...state,
        isAuthenticated: action.payload,
        error: null,
      };
    case 'LOGIN_FAIL':
      return {
        ...state,
        isAuthenticated: false,
        error: action.payload,
      };
    case 'LOGOUT':
      return {
        ...state,
        isAuthenticated: action.payload,
        error: null,
      };
    default:
      return state;
  }
};

export default authReducer;
