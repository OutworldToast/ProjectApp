import LinkButton from "./LinkButton.js";

function ToolbarStart(){
    return (
        <div className="toolbar-start">
            <LinkButton 
            body = {"Login"}
            link = {"/LoginPage"}
            />
            <LinkButton
            body = {"Registreer"}
            link = {"/RegisterPage"}
            />

        </div>

    )

}

export default ToolbarStart;