const newsState = {
  data: [],
  post: {}
};

const newsReducer = (state = newsState, action) => {
  switch (action.type) {
    case "GET_NEWS":
      return {
        data: action.payload,
      };
    case "UPDATE_NEWS":
      return {
        data: action.payload,
      };
    case "GET_POST_DATA":
      return {
        post: action.payload
      }

    default:
      return state;
  }
};

export default newsReducer;
