import React from "react";

import Row from "react-bootstrap/Row";
import Col from "react-bootstrap/Col";
import Button from "react-bootstrap/Button";
import Container from "react-bootstrap/Container";

import Map from "../../Map/Map";


const Information = ({championship}) => {

  return (
    <>
      <Container className="mt-4">
        <Row className="mb-3">
          <Col lg={4}>
            <h3>RELEVANT DATES:</h3>
            <p>
              Date of the event: <br />
              <span className="text-dark">{championship.dateTime}</span>
            </p>
            <p>
              Registration for the event: <br />
              <span className="text-dark">12 Sep - 25 Nov, 2023 - 23:59</span>
            </p>
            <p>
              Brackets Release Date: <br />
              <span className="text-dark">29 Nov, 2023</span>
            </p>
          </Col>
          <Col lg={4}>
            <h3>REGISTRATION FEE</h3>
            <p className="text-dark">
              Normal: <span>&euro;</span>{championship.registrationFee}
              <br />
              Late: <span>&euro;</span>35
            </p>
          </Col>
          <Col
            lg={{ span: 4, order: "last" }}
            xs={{ order: "first" }}
            className="text-center mb-5"
          >
            <Button href="/" variant="light" size="lg">
              Register Now
            </Button>
          </Col>
        </Row>
        <Row>
          <Col md={4}>
            <h3 className="mb-3">LOCATION</h3>
            <p className="text-dark">
              {championship.location}
            </p>
          </Col>
          <Col md={8} className="map-height">
            <Map />
          </Col>
        </Row>
      </Container>
      <Container className="mt-4">
        <Row>
          <Col>
            {championship.description}
          </Col>
        </Row>
      </Container>
    </>
  );
};

export default Information;
