import App from "../App";
import Details from "../pages/details";
import React, { useEffect } from 'react';
import { Route, Routes, useLocation } from 'react-router-dom';

const AppRoute = () => {
  const location = useLocation();
  useEffect(() => {
    document.title = 'My React App';
  }, [location]);

return (
    <Routes>
      
      <Route path="/" element={<App />} />
      <Route path="/Details/:id" element={<Details />} />
      </Routes>
);
};

export default AppRoute;

    