import 'bootstrap/dist/css/bootstrap.min.css';
import CustomNavbar from './components/Navbar/CustomNavbar';
import Acomp from './components/Acomp';

function App() {
  return (
    <>
        <CustomNavbar/>
        <h1 className="text-3xl font-bold underline">
          Hello world!
        </h1>
        <Acomp/>
        <Acomp/>
        <Acomp/>
        <Acomp/>
    </>
  );
}

export default App;
