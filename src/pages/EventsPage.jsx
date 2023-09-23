import React from 'react'
import Events from '../components/Events/Events'
import Footer from '../components/Footer/Footer'

function EventsPage() {
  return (
    <div style={{ paddingTop: '80px', backgroundColor: '#183D3D', minHeight: '100vh' }}>
      <Events />
      <Footer backgroundColor="#183D3D" />
    </div>
  );
}

export default EventsPage;
