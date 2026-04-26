function MediaCard({ title, year, genre, director, format }) {
    return (
        <div className="media-card">
            <h2>{title}</h2>
            <p>Year: {year}</p>
            <p>Genre: {genre}</p>
            <p>Director: {director}</p>
            <p>Format: {format}</p>
        </div>
    );
}

export default MediaCard;