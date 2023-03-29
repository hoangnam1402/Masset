import React from "react";
import ReactDOM from "react-dom";
import NProgress from "nprogress";
import { BrowserRouter } from "react-router-dom";
import { Provider } from "react-redux";

import store from "./redux/store";
import Routes from "./routes";
import reportWebVitals from './reportWebVitals';

NProgress.configure({ minimum: 1 });

function App() {
  return (
    <Provider store={store}>
      <BrowserRouter>
        <Routes />
      </BrowserRouter>
    </Provider>
  );
}

const ROOT = document.getElementById("root");
ReactDOM.render(<App />, ROOT);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
