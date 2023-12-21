import Button from "./Button.js";
import LinkButton from "./LinkButton.js";

function Navigatiebalk() {

    return (
        <div class = "navbar">

            <Button 
            message = {"->> open profiel"}
            body = {"Profiel"}
            />


            <LinkButton
            link={'/ChatPage'}
            body={'Chat'}
            />

    
            <LinkButton
            link={'/HomePage'}
            body={'Home'}
            />
            
            <LinkButton
            link = {'/LoginPage'}
            body = {'Login'}
            />
            
        </div>
    )

}

export default Navigatiebalk;