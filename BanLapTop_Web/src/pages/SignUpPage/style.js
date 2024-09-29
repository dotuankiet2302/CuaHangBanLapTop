import styled from "styled-components";

export const WapperLable= styled.h1`
    font-size: 32px;
    font-weight: bold; 
    color: rgb(75, 0, 130); 
    background: linear-gradient(135deg, rgb(75, 0, 130), rgba(255, 255, 255, 0.3));
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
    text-shadow: 1px 1px 3px rgba(255, 255, 255, 0.5), 
                 1px 1px 5px rgba(128, 0, 128, 0.7);
    padding: 10px;
    border-radius: 5px; 
`
export const WrapperContainerLeft= styled.div`
    flex: 1;
    padding: 40px 45px 24px;
    flex-direction: column;
    display: flex;
`
export const WrapperContainerRight= styled.div`
    width: 300px;
   // background: linear-gradient(136deg, rgb(240,248,255)-1%, rgb(219,238,255) 85%);
   background: linear-gradient(136deg, rgb(230, 230, 255) -1%, rgb(200, 200, 255) 85%);
    display: flex;
    justify-content: center;
    flex-direction: column;
    align-items: center;
    gap: 4px;
`
export const WrapperTextLight= styled.span`
    color: rgb(13,92,183);
    font-size: 13px;
`