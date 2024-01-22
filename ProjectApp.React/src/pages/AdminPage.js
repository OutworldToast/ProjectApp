import UserList from "../components/UserList";
import ResearchList from "../components/ResearchList";
import Navigatiebalk from "../components/Navigatiebalk";

const AdminPage = () => {
    return (
        <div>
        <Navigatiebalk/>
        <UserList />
        <ResearchList />
        </div>
      );
}

export default AdminPage;