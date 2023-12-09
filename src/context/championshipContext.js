import React, { createContext, useContext, useEffect, useState } from "react";
import apiService from "../services/apiService";

const ChampionshipContext = createContext();

const ChampionshipProvider = ({ children }) => {
  const [championships, setChampionships] = useState([]);

  useEffect(() => {
    const getChampionships = async () => {
      try {
        const response = await apiService.getChampionships();
        setChampionships(response);
      } catch (error) {
        console.log("Error fetching posts:", error);
      }
    };

    getChampionships();
  }, []);

  return (
    <ChampionshipContext.Provider value={{ championships }}>
      {children}
    </ChampionshipContext.Provider>
  );
};

const useChampionships = () => {
  return useContext(ChampionshipContext);
};

export { ChampionshipProvider, useChampionships };
