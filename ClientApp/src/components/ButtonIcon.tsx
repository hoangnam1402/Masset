import React from 'react';

type Props = {
    children: React.ReactNode;
    disable?: boolean;
    className?: string;
    onClick?: Function;
    title?: string;
}

const ButtonIcon: React.FC<Props> = ({ children, disable, onClick, className, title }) => {
    const style = disable ? 'disable' : 'pointer';

    const handleClick = (e: any) => {
        e.stopPropagation();

        if (disable) return;

        if (onClick) onClick();
    }

    return (
        <div onClick={handleClick} className={`${style} ${className}`} title={`${title}`}>
            {children}
        </div>
    );
};

export default ButtonIcon;
