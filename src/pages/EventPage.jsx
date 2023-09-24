import React from 'react';
import coverImg from '../assets/photos/bg-mustard-color.jpg';
import Footer from '../components/Footer/Footer';
import Image from 'react-bootstrap/Image';
import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import Button from 'react-bootstrap/Button';
import Nav from 'react-bootstrap/Nav';
import './EventPage.css'

function EventPage() {
    return (
        <div style={{ paddingTop: '75px', backgroundColor: '#5c8374', minHeight: '100vh' }}>
            <Image src={coverImg} fluid className='event-banner' />
            <div className='event-data mx-auto'>
                <Nav className="justify-content-center" activeKey="/home">
                    <Nav.Item>
                        <Nav.Link href="/home">Active</Nav.Link>
                    </Nav.Item>
                    <Nav.Item>
                        <Nav.Link eventKey="link-1">Link</Nav.Link>
                    </Nav.Item>
                    <Nav.Item>
                        <Nav.Link eventKey="link-2">Link</Nav.Link>
                    </Nav.Item>
                    <Nav.Item>
                        <Nav.Link eventKey="disabled" disabled>
                            Disabled
                        </Nav.Link>
                    </Nav.Item>
                </Nav>
                <Container className="mt-4">
                    <Row>
                        <Col md={6}>
                            <h3>INFORMATION</h3>
                            <strong>RELEVANT DATES</strong>
                            <p>
                                Date of the event: <span className="text-dark">December 2nd - 3rd, 2023</span>
                            </p>
                            <p>
                                Registration for the event: <span className="text-dark">12 Sep - 25 Nov, 2023 - 23:59</span>
                            </p>
                            <p>
                                Brackets Release Date: <span className="text-dark">29 Nov, 2023</span>
                            </p>
                        </Col>
                        <Col md={6} className="d-flex justify-content-end align-items-start">
                            <Button href="/events" variant="light" size="lg" style={{ fontFamily: 'Roboto, sans-serif' }}>
                                Register Now
                            </Button>
                        </Col>
                    </Row>
                </Container>


                {/* Location, Registration Fee, and Buttons */}
                <Container className="mt-4">
                    <Row>
                        <Col md={4}>
                            <h3>LOCATION</h3>
                            <p>
                                Sport Ireland National Indoor Arena
                                <br />
                                Snugborough Road, Blanchardstown
                                <br />
                                Dublin 15
                            </p>
                        </Col>
                        <Col md={4}>
                            <h3>REGISTRATION FEE</h3>
                            <p>
                                Normal: <span>&euro;</span>30
                                <br />
                                Late: <span>&euro;</span>35
                            </p>
                        </Col>
                        <Col md={4}>
                            <Button href="#" className='btn-style mb-2' variant="outline-light" size="md" style={{ fontFamily: 'Roboto, sans-serif' }}>
                                List of Participants
                            </Button>
                            <br />
                            <Button href="#" className='btn-style mb-2' variant="outline-light" size="md" style={{ fontFamily: 'Roboto, sans-serif' }}>
                                Brackets
                            </Button>
                            <br />
                            <Button href="#" className='btn-style mb-2' variant="outline-light" size="md" style={{ fontFamily: 'Roboto, sans-serif' }}>
                                Results
                            </Button>
                        </Col>
                    </Row>
                </Container>

                <h2 className='mt-5'>BELT & AGE DIVISIONS</h2>
                <p>BELT AND AGE DIVISIONS</p>
                <p>MEN'S:</p>

                <table>
                    <thead>
                        <tr>
                            <th>Year of Birth</th>
                            <th>Division</th>
                            <th>Belt</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>2018 and 2019</td>
                            <td>Kids 1</td>
                            <td>White, Grey</td>
                        </tr>
                        <tr>
                            <td>2016 and 2017</td>
                            <td>Kids 2</td>
                            <td>White, Grey, Yellow</td>
                        </tr>
                        <tr>
                            <td>2014 and 2015</td>
                            <td>Kids 3</td>
                            <td>White, Grey, Yellow</td>
                        </tr>
                        <tr>
                            <td>2012 and 2013</td>
                            <td>Infant</td>
                            <td>White, Grey, Yellow, Orange</td>
                        </tr>
                        <tr>
                            <td>2010 and 2011</td>
                            <td>Junior</td>
                            <td>White, Grey, Yellow, Orange, Green</td>
                        </tr>
                        <tr>
                            <td>2008 and 2009</td>
                            <td>Teen</td>
                            <td>White, Grey, Yellow, Orange, Green</td>
                        </tr>
                        <tr>
                            <td>2006 and 2007</td>
                            <td>Youth</td>
                            <td>White, Blue, Purple</td>
                        </tr>
                        <tr>
                            <td>2005 and before</td>
                            <td>Amateur</td>
                            <td>White, Blue</td>
                        </tr>
                        <tr>
                            <td>2007 and before</td>
                            <td>Professional</td>
                            <td>Purple</td>
                        </tr>
                        <tr>
                            <td>2005 and before</td>
                            <td>Professional</td>
                            <td>Brown, Black</td>
                        </tr>
                        <tr>
                            <td>1993 and before</td>
                            <td>Master 1</td>
                            <td>White, Blue, Purple, Brown, Black</td>
                        </tr>
                        <tr>
                            <td>1987 and before</td>
                            <td>Master 2</td>
                            <td>White, Blue, Purple, Brown, Black</td>
                        </tr>
                    </tbody>
                </table>

            </div>
            <Footer />
        </div>
    );
}

export default EventPage;
