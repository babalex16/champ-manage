import React, { useState } from "react";
import { Form, FormGroup, Container, Button, Col, Row } from "react-bootstrap";
import '../utils/AccountPage.css'

function AccountPage() {
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

  const handleFormChange = (event) => {
    setFormData({ ...formData, [event.target.name]: event.target.value });
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    // Send the form data to your API here
  };

  return (
    <div
      style={{
        paddingTop: "75px",
        backgroundColor: "#5c8374",
        minHeight: "100vh",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Container className="account-container m-4"
      >
        <h3 className="header">
          User details
        </h3>
        <Form>
          <FormGroup className="mb-2">
            <Row className="container-fluid">
              <Col className="col-md-2">
                <Form.Label className="text-black">First Name</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Control type="text" value="vlad" plaintext />
              </Col>
            </Row>
          </FormGroup>
          <FormGroup className="mb-2">
            <Row className="container-fluid">
              <Col className="col-md-2">
                <Form.Label className="text-black">Last Name</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Control type="text" value="zara" plaintext />
              </Col>
            </Row>
          </FormGroup>
          <FormGroup className="mb-2">
            <Row className="container-fluid">
              <Col className="col-md-2">
                <Form.Label className="text-black">Email Adress</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Control
                  className=""
                  type="text"
                  value="vlad.zara@email.com"
                  plaintext
                />
              </Col>
            </Row>
          </FormGroup>

          <Button variant="secondary" className="m-4 ">
            Change Password
          </Button>
        </Form>

        <h3 className="header">
          Participant Data
        </h3>
        <Form>
          <Form.Group className="p-2">
            <Row className="container-fluid">
              <Col className="col-md-2">
                <Form.Label className="text-black">Gender</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Select
                  name="gender"
                  value={formData.gender}
                  onChange={handleFormChange}
                >
                  <option value="" disabled hidden>Choose an option...</option>
                  <option value="male">Male</option>
                  <option value="female">Female</option>
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
            <Row className="container-fluid">
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
            <Row className="container-fluid">
              <Col className="col-md-2">
                <Form.Label className="text-black mt-2">Weight</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Control
                  type="number"
                  name="weight"
                  value={formData.weight}
                  onChange={handleFormChange}
                />
              </Col>
            </Row>
          </Form.Group>

          <Form.Group className="p-2">
            <Row className="container-fluid">
              <Col className="col-md-2">
                <Form.Label className="text-black mt-2">Belt</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Select
                  name="belt"
                  value={formData.belt}
                  onChange={handleFormChange}
                >
                  <option value="" disabled hidden>Choose an option...</option>
                  <option value="White">White</option>
                  <option value="Yellow">Blue</option>
                  <option value="Orange">Purple</option>
                  <option value="Green">Brown</option>
                  <option value="Black">Black</option>
                </Form.Select>
              </Col>
            </Row>
          </Form.Group>

          <Form.Group className="p-2">
            <Row className="container-fluid">
              <Col className="col-md-2">
                <Form.Label className="text-black mt-2">Phone</Form.Label>
              </Col>
              <Col className="col-md-10">
                <Form.Control
                  type="text"
                  name="phone"
                  value={formData.phone}
                  onChange={handleFormChange}
                />
              </Col>
            </Row>
          </Form.Group>

          <Button variant="primary" type="submit" className="m-4 mx-auto d-block">
            Save Changes
          </Button>
        </Form>
      </Container>
    </div>
  );
}

export default AccountPage;
