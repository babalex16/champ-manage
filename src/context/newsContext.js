import React, { createContext, useContext, useEffect, useState } from "react";
import apiService from "../services/apiService";

const NewsContext = createContext();

const NewsProvider = ({ children }) => {
  const [news, setNews] = useState([]);

  useEffect(() => {
    const getPosts = async () => {
      try {
        const response = await apiService.getPosts();
        setNews(response);
      } catch (error) {
        console.log("Error fetching posts:", error);
      }
    };

    getPosts();
  }, []);

  return (
    <NewsContext.Provider value={{ news }}>{children}</NewsContext.Provider>
  );
};

const useNews = () => {
  return useContext(NewsContext);
};

export { NewsProvider, useNews };
