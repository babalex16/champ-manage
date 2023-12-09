import React from "react";
import { Link } from "react-router-dom";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";

import { useChampionships } from "../../context/championshipContext";

import bannerImage from "../../assets/photos/banner.jpg";
import "./championships.css";

const Championships = () => {
  const { championships } = useChampionships();

  return (
    <section id="events" className="events-background">
      <div className="events-container">
        <div>
          <h3 className="text-white text-uppercase text-center customFont my-5">
            Upcoming events
          </h3>
          <Row xs={1} md={2} xl={4} className="g-3">
            {championships.map((championship, idx) => (
              <Col key={idx}>
                <Card className="event-card">
                  <Link
                    to={{
                      pathname: `/championship/${idx}`,
                    }}
                  >
                    <Card.Img variant="top" src={bannerImage} />
                  </Link>
                  <Card.Body>
                    <Card.Text className="text-white text-center">
                      DATE OF THE EVENT: &nbsp;&nbsp;&nbsp; {championship.dateTime}
                    </Card.Text>
                  </Card.Body>
                </Card>
              </Col>
            ))}
          </Row>
        </div>
      </div>
    </section>
  );
};

export default Championships;
