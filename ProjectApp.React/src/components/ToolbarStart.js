import Button from "./Button.js";
import LinkButton from "./LinkButton.js";

function ToolbarStart(){
    return (
        <div className="toolbar-start">
            <LinkButton 
            body = {"Login"}
            link = {"/LoginPage"}
            />
            <Button
            body = {"Registreer"}
            link = {"/RegisterPage"}
            />

        </div>

    )

}

export default ToolbarStart;