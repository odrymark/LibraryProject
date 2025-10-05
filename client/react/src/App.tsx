import {createBrowserRouter, type RouteObject, RouterProvider} from 'react-router-dom';
import './App.css'
import './style.css'
import Home from "./pages/Home.tsx";
import Books from "./pages/Books.tsx";
import AddBook from "./pages/AddBook.tsx";
import Authors from "./pages/Authors.tsx";
import Genres from "./pages/Genres.tsx";
import ByAuthor from "./pages/ByAuthor.tsx";
import ByGenre from "./pages/ByGenre.tsx";
import {useEffect} from "react";
import {useSetAtom} from "jotai";
import {fetchBooksAtom} from "./atoms/BooksAtom.ts";
import {fetchAuthorsAtom} from "./atoms/AuthorsAtom.ts";
import {fetchGenresAtom} from "./atoms/GenresAtom.ts";

const routes : RouteObject[] = [
    { path: "/", element: <Home/> },
    { path: "/books", element: <Books/> },
    { path: "/addBook", element: <AddBook/> },
    { path: "/authors", element: <Authors/> },
    { path: "/genres", element: <Genres/> },
    { path: "/booksByAuthor/:author", element: <ByAuthor/> },
    { path: "/booksByGenre/:genre", element: <ByGenre/> }
]

function App() {
    const fetchBooks = useSetAtom(fetchBooksAtom);
    const fetchAuthors = useSetAtom(fetchAuthorsAtom);
    const fetchGenres = useSetAtom(fetchGenresAtom);

    useEffect(() => {
        fetchBooks();
        fetchAuthors();
        fetchGenres();
    }, [fetchBooks, fetchAuthors, fetchGenres]);

    return <RouterProvider router={createBrowserRouter(routes)}/>
}

export default App
