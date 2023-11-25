const initialState = {
    jwt : "", 
    userType : "Participant", 
    isExpired : false 
}

const authReducer = (state = initialState, action) => {
    switch (action.type) {
      case 'SET_JWT':
        return {
          ...state,
          jwt: action.payload,
        };
      case 'SET_USER_TYPE':
        return {
          ...state,
          userType: action.payload,
        };
      case 'SET_IS_EXPIRED':
        return {
          ...state,
          isExpired: action.payload,
        };
      default:
        return state;
    }
  };
  
  export default authReducer;