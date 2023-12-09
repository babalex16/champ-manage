const apiService = {
  getPosts: async () => {
    try {
      const response = await fetch(
        `${process.env.REACT_APP_CHAMP_MANAGE_API}/api/news`,
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      if (response.status !== 200) {
        throw new Error(`Status response ${response.status}`);
      }
      const data = await response.json();

      return data;
    } catch (error) {
      throw new Error(error.message);
    }
  },

  getChampionships: async () => {
    try {
      const response = await fetch(
        `${process.env.REACT_APP_CHAMP_MANAGE_API}/api/championships`,
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      if (response.status !== 200) {
        throw new Error(`Status response ${response.status}`);
      }
      const data = await response.json();

      return data;
    } catch (error) {
      throw new Error(error.message);
    }
  },
};

export default apiService;
