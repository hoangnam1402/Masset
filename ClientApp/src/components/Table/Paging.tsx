import React from 'react';
import { ThreeDots } from 'react-bootstrap-icons';

export type PageType = {
    currentPage?: number;
    totalPage?: number;
    handleChange: (page: number) => void;
}

const Paging: React.FC<PageType> = ({ currentPage = 1, totalPage = 1, handleChange }) => {
    const prePageStyle = currentPage !== 1 ? 'pagination__link' : 'pagination__link link-disable';
    const nextPageStyle = currentPage + 1 <= totalPage ? 'pagination__link' : 'pagination__link link-disable';

    const pageStyle = (page: number) => {
        if (page === currentPage) return 'pagination__link link-active';
        return 'pagination__link';
    };

    let limitPage = 0;
    const pageLength = 5;
    if (totalPage > pageLength) {
        limitPage = pageLength;
    } else {
        limitPage = totalPage;
    }

    const onPrev = (e: any) => {
        e.preventDefault();

        if (currentPage !== 1) {
            handleChange(currentPage - 1);
        }
    };

    const onNext = (e: any) => {
        e.preventDefault();

        if (currentPage + 1 <= totalPage) {
            handleChange(currentPage + 1);
        }
    };

    const onPageNumber = (e: any, page: number) => {
        e.preventDefault();
        handleChange(page);
    };

    return (
        <ul className="pagination mt-2">
            <li className="intro-x">
                <a onClick={onPrev} className={prePageStyle}>
                    Previous
                </a>
            </li>


            {currentPage > 3 && (
            <li>
                <a
                onClick={(e) => onPageNumber( 
                    e,
                    totalPage - currentPage < 3 ? 
                    totalPage - pageLength :
                    currentPage - 3 
                    )
                }
                className={pageStyle(
                    totalPage - currentPage < 3 ? 
                    totalPage - pageLength :
                    currentPage - 3
                    )}
                >
                    <ThreeDots/>
                </a>
            </li>
            )}


            {[...Array(limitPage).keys()]
                .map((i) => {
                    const limitPerSide = Math.floor(pageLength / 2);
                    if (currentPage <= limitPerSide)
                    return i + Math.ceil(currentPage / limitPerSide);
                    if (currentPage > totalPage - limitPerSide)
                    return i + totalPage + 1 - limitPage;
                    return i + currentPage - limitPerSide;
                })
                .map((i) => (
                    <li key={i}>
                    <a onClick={(e) => onPageNumber(e, i)} className={pageStyle(i)}>
                        {i}
                    </a>
                    </li>
                ))
            }

            {currentPage < (totalPage - 2 ) && (
            <li>
                <a
                onClick={(e) => onPageNumber( 
                    e,
                    currentPage < 3 ? 
                    pageLength + 1 :
                    currentPage + 3
                    )
                }
                className={pageStyle(
                    currentPage < 3 ? 
                    pageLength :
                    currentPage + 3 
                    )}
                >
                    <ThreeDots/>
                </a>
            </li>
            )}

            <li className="intro-x">
                <a onClick={onNext} className={nextPageStyle}>Next</a>
            </li>
        </ul>
    );
};

export default Paging;