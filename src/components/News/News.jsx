import React from 'react';
import Card from 'react-bootstrap/Card';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Button from 'react-bootstrap/Button';
import './News.css';
import bannerImage from '../../assets/photos/banner.jpg';

const newsData = [
  {
    imageSrc: bannerImage, 
    date: '20-09-2023',
    title: 'Title',
    text: 'This is the content of card 1.',
    link: '#',
  },
  {
    imageSrc: bannerImage, 
    date: '05-10-2023',
    title: 'Title',
    text: 'This is the content of card 2.',
    link: '#',
  },
  {
    imageSrc: bannerImage,
    date: '15-11-2023',
    title: 'Title',
    text: 'This is the content of card 3.',
    link: '#',
  },
  
];

function News() {
  return (
    <section id='news' className='news-background'>
        <h3 className='news-title pt-5'>Recent News</h3>
        <div className='news-container'>
            <Row xs={1} sm={1} md={2} xl={3} className="g-3 news-row mb-3">
              {newsData.map((news, idx) => (
                <Col key={idx}>
                  <Card className='news-card'>
                    <a href={news.link}>
                      <Card.Img variant="top" src={news.imageSrc} />
                    </a>
                    <Card.Body>
                      <Card.Title >{news.title}</Card.Title>
                      <Card.Text >{news.text}</Card.Text>
                    </Card.Body>
                    <Card.Footer className='text-muted'>{news.date}</Card.Footer>
                  </Card>
                </Col>
              ))}
            </Row>
          </div>
      <div className='text-center py-5'>
        <Button href="/news" variant="outline-light" size="md" className='customFont '>
          ALL NEWS
        </Button>
      </div>
    </section>
  );
}

export default News;