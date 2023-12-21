import Button from "./Button.js";
import LinkButton from "./LinkButton.js";

function Toolbar() {

    return (
        <div>
            <Button 
            message = {"->> open profiel"}
            body = {"Profiel"}
            />

            <Button 
            message = {"->> open chat"}
            body = {"Chat"}
            />

            <Button 
            message = {"->> open onderzoek"}
            body = {"Onderzoeken"}
            />
            
            <LinkButton/>
            
        </div>
    )

}

export default Toolbar;