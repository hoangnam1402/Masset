import React, { Suspense } from "react";
import { Navigate, Route } from "react-router-dom";

import { LOGIN } from "../constants/pages";
import Layout from "../containers/Layout";
import { useAppSelector } from "../hooks/redux";

export default function PrivateRoute({ children }: any) {
    const { isAuth } = useAppSelector(state => state.authReducer);

    return isAuth ? 
        <Layout>
            {children}
        </Layout> :
        <Navigate to={LOGIN} />;
}