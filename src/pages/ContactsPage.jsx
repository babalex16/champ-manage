import React from 'react';
import coverImg from '../assets/photos/mjjf-fb-cover.png';
import Footer from '../components/Footer/Footer';
import Image from 'react-bootstrap/Image';
import { Container, Table } from 'react-bootstrap';

function ContactsPage() {
  return (
    <div style={{ paddingTop: '75px', backgroundColor: '#5c8374', minHeight: '100vh' }}>
      <Image src={coverImg} fluid />;
      <h2 className="text-white text-center mt-4">Contacts</h2>
      <h5 className='text-white my-3'>  </h5>
      <Container className="mt-5">
        <Table striped bordered hover responsive>
          <thead>
            <tr>
              <th>Coach</th>
              <th>Address</th>
              <th>Schedule</th>
              <th>Phone Number</th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>Roman Babii</td>
              <td>Bulevardul Decebal 2, Chisinau</td>
              <td>
                  <p>Monday, Wednesday, Friday</p>
                <ul>
                  <li>16:00-17:00 / 6-9 years</li>
                  <li>17:00-18:15 / 10-12 years</li>
                  <li>18:30-19:45 / 12-15 years</li>
                  <li>20:00-21:30 / 16+ years</li>
                </ul>
              </td>
              <td>
                +373 688 40 540
              </td>
            </tr>
            <tr>
              <td>Artem Kitaev</td>
              <td>
                str.Alba-Iulia 113, Sport House, Chisinau
              </td>
              <td>
                <ul>
                  <li>Monday-Friday: 08:00-22:00</li>
                  <li>Saturday: 08:00-20:00</li>
                </ul>
              </td>
              <td>
                +373 681 32 424
              </td>
            </tr>
            <tr>
              <td>Vlad Trifanov</td>
              <td>
                str. Eugen Doga 5, Chisinau
              </td>
              <td>
                <ul>
                  <li>Tuesday, Thursday: 17:00-21:30</li>
                  <li>Saturday: 10:00-13:30</li>
                </ul>
              </td>
              <td>
                +373 680 55 447
              </td>
            </tr>
          </tbody>
        </Table>
      </Container>
      <Footer />
    </div>
  );
}

export default ContactsPage;
