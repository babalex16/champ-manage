import Cookies from "js-cookie";
import { jwtDecode } from "jwt-decode";

const authService = {
  registerUser: async (registerDetails) => {
    try {
      const response = await fetch(
        `${process.env.REACT_APP_CHAMP_MANAGE_API}/api/account/register`,
        {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(registerDetails),
        }
      );
      const data = await response.json();
      Cookies.set("jwtToken", data.token, { domain: "localhost", path: "/" });
    } catch (error) {
      console.error("register failed:", error);
    }
  },

  getUserToken: async (loginDetails) => {
    try {
      const response = await fetch(
        `${process.env.REACT_APP_CHAMP_MANAGE_API}/api/account/login`,
        {
          method: `POST`,
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify(loginDetails),
        }
      );

      if (response.status !== 200) {
        throw new Error(`status response ${response.status}`);
      }
      const data = await response.json();
      console.log("data :>> ", data);
      Cookies.set("jwtToken", data.token, { domain: "localhost", path: "/" });

      return data.token;
    } catch (error) {
      throw new Error(error.message);
    }
  },

  getUserById: async (token) => {
    try {
      const decodedToken = jwtDecode(token);

      const response = await fetch(
        `${process.env.REACT_APP_CHAMP_MANAGE_API}/api/users/${decodedToken.user_id}`,
        {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
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

  updateUserDetails: async ({
    gender,
    birthdate,
    teamName,
    weight,
    belt,
    phone,
  }) => {
    try {
      const userDetails = {
        gender,
        birthdate,
        teamName,
        weight,
        belt,
        phone,
      };
      const decodedToken = jwtDecode(Cookies.get("jwtToken"));
      const requestBody = Object.keys(userDetails).map((key) => ({
        op: "replace",
        path: `/${key}`,
        value: userDetails[key],
      }));

      await fetch(
        `${process.env.REACT_APP_CHAMP_MANAGE_API}/api/users/${decodedToken.user_id}`,
        {
          method: "PATCH",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${Cookies.get("jwtToken")}`,
          },
          body: JSON.stringify(requestBody),
        }
      );
    } catch (error) {
      throw new Error(error.message);
    }
  },

  signOut: () => {
    const cookies = document.cookie.split(";");
    for (const cookie of cookies) {
      document.cookie =
        cookie.trim() + "; expires=Thu, 01-Jan-1970 00:00:00 UTC;";
    }
  },
};

export default authService;
