import React from "react";
import Card from "react-bootstrap/Card";
import Col from "react-bootstrap/Col";
import Row from "react-bootstrap/Row";
import { Link } from "react-router-dom";

import { useNews } from "../../context/newsContext";

import newsImages from "../../assets/newsPosts";

import "./News.css";

const News = () => {
  const { news } = useNews();

  return (
    <section id="news" className="news-background">
      <h3 className="news-title pt-5">Recent News</h3>
      <div className="news-container">
        <Row xs={1} sm={1} md={2} xl={4} className="g-4 news-row mb-4 ">
          {news.map((news, idx) => (
            <Col key={idx}>
              <Card className="news-card">
                <Link
                  to={{
                    pathname: `/newspage/${idx}`,
                  }}
                >
                  <Card.Img variant="top" src={newsImages[idx]} />
                </Link>
                <Card.Body>
                  <Card.Title>{news.title}</Card.Title>
                  <Card.Text>{news.dateOfArticle}</Card.Text>
                </Card.Body>
                <Card.Footer className="text-muted">{news.date}</Card.Footer>
              </Card>
            </Col>
          ))}
        </Row>
      </div>
    </section>
  );
};

export default News;
