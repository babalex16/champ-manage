import React from 'react';
import Image from 'react-bootstrap/Image';
import Container from 'react-bootstrap/Container';
import Tab from 'react-bootstrap/Tab';
import Tabs from 'react-bootstrap/Tabs';
import Row from 'react-bootstrap/Row';
import Footer from '../components/Footer/Footer';
import Col from 'react-bootstrap/Col';
import Dropdown from 'react-bootstrap/Dropdown';
import Table from 'react-bootstrap/Table';
import coverImg from '../assets/photos/bg-mustard-color.jpg';
import './EventPage.css';

function EventPage() {

    return (
        <div style={{ paddingTop: '75px', backgroundColor: '#5c8374', minHeight: '100vh' }}>
            <Image src={coverImg} fluid className='event-banner' />
            <div className='event-data mx-auto'>
                <Tabs
                    defaultActiveKey="information"
                    id="event-tabs"
                    className="mb-5"
                    fill
                >
                    <Tab eventKey="information" title="Information">
                        {/* Content for INFORMATION tab */}
                        <Container className="mt-4">
                            <Row>
                                <Col md={4}>
                                    <h3>RELEVANT DATES:</h3>
                                    <p>
                                        Date of the event: <br /> <span className="text-dark">December 2nd - 3rd, 2023</span>
                                    </p>
                                    <p>
                                        Registration for the event: <br /> <span className="text-dark">12 Sep - 25 Nov, 2023 - 23:59</span>
                                    </p>
                                    <p>
                                        Brackets Release Date: <br /> <span className="text-dark">29 Nov, 2023</span>
                                    </p>
                                </Col>
                                <Col md={4}>
                                    <h3>LOCATION</h3>
                                    <p className="text-dark">
                                        Sport Ireland National Indoor Arena
                                        <br />
                                        Snugborough Road, Blanchardstown
                                        <br />
                                        Dublin 15
                                    </p>
                                </Col>
                                <Col md={4}>
                                    <h3>REGISTRATION FEE</h3>
                                    <p className="text-dark">
                                        Normal: <span>&euro;</span>30
                                        <br />
                                        Late: <span>&euro;</span>35
                                    </p>
                                </Col>
                            </Row>
                        </Container>
                        <Container className="mt-4">
                            <Row>
                                <Col>
                                    <h2 className='mt-5'>BELT & AGE DIVISIONS</h2>
                                    <p>BELT AND AGE DIVISIONS</p>
                                    {/* Table content  */}
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
                                </Col>
                            </Row>
                        </Container>
                    </Tab>

                    <Tab eventKey="participants" title="List of Participants">
                        <div>
                            <Container>
                                <Row>
                                    <Col>
                                        <h1 className='mb-5'> Participants</h1>
                                    </Col>
                                    <Col className='text-end'>
                                        <Dropdown>
                                            <Dropdown.Toggle variant="secondary" size='lg' id="belt-dropdown">
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
                                        <h5>Age/Gender/Weight Category (XXkg)</h5>
                                    </Col>
                                    <Col >
                                        <p className='text-end'>TOTAL: 3</p>
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
                        </div>
                    </Tab>

                    <Tab eventKey="brackets" title="Brackets">
                        {/* Content for Brackets tab */}
                    </Tab>

                    <Tab eventKey="results" title="Results">
                        {/* Content for Results tab */}
                    </Tab>
                </Tabs>
                <Footer />
            </div>
        </div>
    );
}

export default EventPage;
