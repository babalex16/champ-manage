export const getNews = (data) => ({
  type: "GET_NEWS",
  payload: data,
});

export const updateNews = (data) => ({
  type: "UPDATE_NEWS",
  payload: data,
});

export const getPostData = (data) => ({
  type: "GET_POST_DATA",
  payload: data,
});
