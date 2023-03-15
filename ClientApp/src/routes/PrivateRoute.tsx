import React, { Suspense, ReactNode } from "react";
import { Navigate, Route } from "react-router-dom";

import { LOGIN } from "../constants/pages";
import Layout from "../containers/Layout";
import { useAppSelector } from "../hooks/redux";
import InLineLoader from "../components/InlineLoader";

interface Props {
    children?: ReactNode
    // any props that come into the component
}

export default function PrivateRoute({ children, ...rest }: Props) {
    const { isAuth } = useAppSelector(state => state.authReducer);

    return (
        <Route
            {...rest}
            render={({ location }) =>
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