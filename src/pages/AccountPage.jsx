import Cookies from "js-cookie";
import React, { useEffect, useState } from "react";
import { Form, FormGroup, Container, Button, Col, Row } from "react-bootstrap";
import authService from "../services/authService/authService";

const AccountPage = () => {
  const [formData, setFormData] = useState({
    firstName: "",
    lastName: "",
    email: "",
    gender: "",
    birthdate: "",
    teamName: "",
    weight: 0,
    belt: "",
    phone: "",
  });

  const beltColors = ["White", "Blue", "Purple", "Brown", "Black"];

  useEffect(() => {
    const user = getUserDatafromCookies();
    setFormData(user);
  }, []);

  const getUserDatafromCookies = () => {
    if (!Cookies.get("user")) {
      return;
    }
    return JSON.parse(Cookies.get("user"));
  };

  // const setDefaultData =

  const handleFormChange = (event) => {
    setFormData({ ...formData, [event.target.name]: event.target.value });
  };

  const handlePhoneChange = (event) => {
    const { name, value } = event.target;
    if (/^\+?\d*$/.test(value)) {
      setFormData({ ...formData, [name]: value });
    }
  };

  const handleWeightChange = (event) => {
    const { name, value } = event.target;
    if (/^\d*(\.\d{0,2})?$/.test(value)) {
      setFormData({ ...formData, [name]: value });
    }
  };

  const handleOptionChange = (name, selectedValue) => {
    setFormData({ ...formData, [name]: selectedValue });
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    await authService.updateUserDetails(formData);
  };

  return (
    <div
      style={{
        paddingTop: "100px",
        paddingBottom: "30px",
        backgroundColor: "#5c8374",
        minHeight: "100vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Container
        style={{
          background: "white",
          padding: "20px",
          borderRadius: "10px",
          width: "50%",
        }}
      >
        <h3 className="text-center text-black font-weight-bold text-uppercase">
          User Details
        </h3>
        <Form>
          <FormGroup className="p-2">
            <Row className="container">
              <Col className="col-md-2 justify-content-center">
                <Form.Label className="text-black">First Name</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Control
                  type="text"
                  defaultValue={formData.firstName}
                  plaintext
                />
              </Col>
            </Row>
          </FormGroup>
          <FormGroup className="p-2">
            <Row className="container">
              <Col className="col-md-2">
                <Form.Label className="text-black">Last Name</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Control
                  type="text"
                  defaultValue={formData.lastName}
                  plaintext
                />
              </Col>
            </Row>
          </FormGroup>
          <FormGroup className="p-2">
            <Row className="container">
              <Col className="col-md-2">
                <Form.Label className="text-black">Email Adress</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Control
                  className=""
                  type="text"
                  defaultValue={formData.email}
                  plaintext
                />
              </Col>
            </Row>
          </FormGroup>
          <Button variant="secondary" className="mt-4">
            Change Password
          </Button>
        </Form>

        <h3 className="text-center text-black font-weight-bold text-uppercase mt-5">
          Participant Data
        </h3>
        <Form onSubmit={handleSubmit}>
          <Form.Group className="p-2">
            <Row className="container-fluid">
              <Col className="col-md-2">
                <Form.Label className="text-black">Gender</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Select
                  name="gender"
                  value={formData.gender}
                  onChange={(e) => handleOptionChange("gender", e.target.value)}
                >
                  {formData.gender !== "" && (
                    <option value="" disabled>
                      Select gender
                    </option>
                  )}

                  {formData.gender.length === 0 && (
                    <option value="" disabled>
                      Select gender
                    </option>
                  )}
                  <option value="Male">Male</option>
                  <option value="Female">Female</option>
                </Form.Select>
              </Col>
            </Row>
          </Form.Group>

          <Form.Group className="p-2">
            <Row className="container-fluid">
              <Col className="col-md-2">
                <Form.Label className="text-black">Birthdate</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Control
                  type="date"
                  name="birthdate"
                  value={formData.birthdate}
                  onChange={handleFormChange}
                />
              </Col>
            </Row>
          </Form.Group>

          <Form.Group className="p-2">
            <Row className="container">
              <Col className="col-md-2">
                <Form.Label className="text-black">Team Name</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Control
                  type="text"
                  name="teamName"
                  placeholder="ex: ZR Team Moldova"
                  value={formData.teamName}
                  onChange={handleFormChange}
                />
              </Col>
            </Row>
          </Form.Group>

          <Form.Group className="p-2">
            <Row className="container">
              <Col className="col-md-2">
                <Form.Label className="text-black mt-2">Weight</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Control
                  type="text"
                  name="weight"
                  value={formData.weight}
                  onChange={handleWeightChange}
                />
              </Col>
            </Row>
          </Form.Group>

          <Form.Group className="p-2">
            <Row className="container">
              <Col className="col-md-2">
                <Form.Label className="text-black mt-2">Belt</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Select
                  name="belt"
                  value={formData.belt}
                  onChange={handleFormChange}
                >
                  {formData.belt !== "" && (
                    <option value="" disabled>
                      Select Belt
                    </option>
                  )}
                  {beltColors.map((color, index) => (
                    <option key={index} value={color}>
                      {color}
                    </option>
                  ))}
                </Form.Select>
              </Col>
            </Row>
          </Form.Group>

          <Form.Group className="p-2">
            <Row className="container">
              <Col className="col-md-2">
                <Form.Label className="text-black mt-2">Phone</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Control
                  type="text"
                  name="phone"
                  value={formData.phone}
                  onChange={handlePhoneChange}
                />
              </Col>
            </Row>
          </Form.Group>

          <Button variant="primary" type="submit" className="mt-4">
            Save Changes
          </Button>
        </Form>
      </Container>
    </div>
  );
};

export default AccountPage;
