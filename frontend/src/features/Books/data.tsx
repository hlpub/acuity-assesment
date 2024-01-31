
//Definetely not the best wat to store config values. Used this only because of time limitations.
//Also, if the API is exposed to the Internet, it should be served overt https. Otherwise
//is better to proxy the requests through the FE server. 

import React from "react";
import Book from "../../shared/book";
import { SearchCriteria } from "../../shared/searchCriteria";

export const baseApiUrl = "http://localhost:5000";


export const populateGrid = (setError: React.Dispatch<React.SetStateAction<string>>,
    setBooks: React.Dispatch<React.SetStateAction<Book[] | null>>,
    querySearch: string, searchCriteria: SearchCriteria) => {

    fetch(`${baseApiUrl}/book/${searchCriteria}/${querySearch}`)
        .then(resp => {

            if (resp.status === 200)
                return resp.json();

            if (resp.status === 401)
                setError(resp.statusText);

            return null;
        })
        .then(res => {

            if (Array.isArray(res)) {
                setBooks(res);
                setError("");
            }

        })
        .catch(() => {
            setError("Books couldn't be retrieved");
        });
}