import React, { Suspense } from "react";
import { Navigate, Route } from "react-router-dom";

import { LOGIN } from "../constants/pages";
import Layout from "../containers/Layout";
import { useAppSelector } from "../hooks/redux";
import InLineLoader from "../components/InlineLoader";

export default function PrivateRoute({ children, ...rest }: any) {
    const { isAuth } = useAppSelector(state => state.authReducer);

    return (
        <Route
            {...rest}
            render={() =>
                isAuth ?
                    (
                        <Suspense fallback={<InLineLoader />}>
                            <Layout>
                                {children}
                            </Layout>
                        </Suspense>
                    )
                    : <Navigate to={LOGIN} />}
        />
    );
}