import logo from './logo.svg';
import './App.css';
import EndPoints from './constants/endpoints'
import { useEffect } from 'react';
import axios from "axios";

function App() {
  const getData = () => {
    axios.get(EndPoints.getUserId(1))
    .catch((error) => {
      console.log(error.response.data)
    })
  }
  useEffect(() => {
    getData();
  },[])
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a
          className="App-link"
          href="https://reactjs.org"
          target="_blank"
          rel="noopener noreferrer"
        >
          Learn React
        </a>
      </header>
    </div>
  );
}

export default App;
