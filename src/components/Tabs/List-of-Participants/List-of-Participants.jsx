import React from "react";

import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Table from "react-bootstrap/Table";
import Button from "react-bootstrap/Button";
import Container from "react-bootstrap/Container";
import Dropdown from "react-bootstrap/Dropdown";

const ListOfParticipants = ({props}) => {
  return (
    <>
      <Container>
        <Row>
          <Col>
            <h1 className="mb-5"> Participants</h1>
          </Col>
          <Col className="text-end">
            <Dropdown>
              <Dropdown.Toggle
                variant="outline-light"
                size="lg"
                id="belt-dropdown"
              >
                Select the belt
              </Dropdown.Toggle>
              <Dropdown.Menu>
                <Dropdown.Item>White Belt</Dropdown.Item>
                <Dropdown.Item>Blue Belt</Dropdown.Item>
                <Dropdown.Item>Purple Belt</Dropdown.Item>
                <Dropdown.Item>Brown Belt</Dropdown.Item>
                <Dropdown.Item>Black Belt</Dropdown.Item>
              </Dropdown.Menu>
            </Dropdown>
          </Col>
        </Row>
      </Container>
      <h3> COLOR belts</h3>

      <Container>
        <Row>
          <Col>
            <div className="d-flex align-items-center mb-2 ">
              <h5>Age/Gender/Weight Category (XXkg) &nbsp;</h5>
              <Button href="/" variant="light" size="md" className="font">
                Bracket
              </Button>
            </div>
          </Col>
          <Col>
            <p className="text-end">TOTAL: 3</p>
          </Col>
        </Row>
        <Row>
          <Table striped bordered hover>
            <thead>
              <tr>
                <th>Team</th>
                <th>Name</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Team A</td>
                <td>John Doe</td>
              </tr>
              <tr>
                <td>Team B</td>
                <td>Jane Smith</td>
              </tr>
              <tr>
                <td>Team C</td>
                <td>Bob Johnson</td>
              </tr>
            </tbody>
          </Table>
        </Row>
      </Container>
    </>
  );
};

export default ListOfParticipants;
