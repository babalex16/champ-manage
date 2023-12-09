export const loginSuccess = () => {
  return {
    type: 'LOGIN_SUCCESS',
    payload: true,
  };
};

export const loginFail = (error) => {
  return {
    type: 'LOGIN_FAIL',
    payload: error,
  };
};

export const logout = () => {
  return {
    type: 'LOGOUT',
    payload: false,
  };
};
