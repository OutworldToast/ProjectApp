import Button from "./Button.js";
import LinkButton from "./LinkButton.js";

function Toolbar() {

    return (
        <div >
            <Button 
            message = {"->> open profiel"}
            body = {"Profiel"}
            />


            <LinkButton
            link={'/ChatPage'}
            body={'Chat'}
            />

          
            
            <LinkButton
            link = {'/LoginPage'}
            body = {'Login'}
            />
            
        </div>
    )

}

export default Toolbar;