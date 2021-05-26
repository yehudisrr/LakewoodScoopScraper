import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';

const LSScraper = () => {
    const [posts, setPosts] = useState([]);

    const getPosts = async () => {
        const { data } = await axios.get(`/api/scraper/scrape`);
        setPosts(data);
    }

    useEffect(() => {
        getPosts();
    }, []);

    return (
        <div className="container">
            <div className="row">
                <div className="col-md-8">
                    <h1 className="my-4">
                        LAKEWOOD SCOOP SCRAPED!
                </h1>
                    {posts && posts.map(post =>
                        <div className="card mb-4">
                            <div className="card-body">
                                <h2 className="card-title">
                                    <a href={post.linkUrl} target="_blank">{post.title}</a>
                                </h2>
                                <img src={post.imageUrl} style={{ width: 200}}/>
                                <p className="card-text">{post.text}
                                    <a href={post.linkUrl} target="_blank">Read More...</a>
                                </p>
                                <div className='mb-3'>
                                    <small>{post.commentsCount}</small>
                                </div>
                            </div>
                        </div>)}
                </div>
            </div>
        </div>
    )
}

export default LSScraper;