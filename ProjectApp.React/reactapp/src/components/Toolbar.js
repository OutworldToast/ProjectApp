import Button from "./Button.js";

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
        </div>
    )

}

export default Toolbar;