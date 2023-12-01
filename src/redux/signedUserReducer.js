const initialUserDto = {
  id: 0,
  firstName: "",
  lastName: "",
  email: "",
  gender: "",
  birthdate: "",
  teamName: "",
  weight: 0,
  belt: "",
  phone: "",
};

export const setUserField = (field, value) => ({
  type: "SET_USER_FIELD",
  payload: { field, value },
});

export const signedUserReducer = (state = initialUserDto, action) => {
  switch (action.type) {
    case "SET_USER_FIELD":
      return {
        ...state,
        [action.payload.field]: action.payload.value,
      };
    default:
      return state;
  }
};