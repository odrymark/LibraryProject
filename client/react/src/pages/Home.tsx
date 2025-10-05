import { useNavigate } from "react-router-dom";

export default function Home() {
    const navigate = useNavigate();

    return (
        <div className="flex flex-col items-center gap-4 p-6">
            <h1 className="text-4xl font-bold">Library</h1>
            <button className="btn btn-primary w-40" onClick={() => navigate("/books")}>Books</button>
            <button className="btn btn-secondary w-40" onClick={() => navigate("/authors")}>Authors</button>
            <button className="btn btn-accent w-40" onClick={() => navigate("/genres")}>Genres</button>
        </div>
    )
}