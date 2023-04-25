

namespace MusicLibrariesManager
{
    class TreeViewFileSystem
    {
        public void ListDirectory(System.Windows.Forms.TreeView treeView, string rootPath)
        {
            treeView.Nodes.Clear();
            System.IO.DirectoryInfo rootDirectoryInfo = new System.IO.DirectoryInfo(rootPath);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private System.Windows.Forms.TreeNode CreateDirectoryNode(System.IO.DirectoryInfo directoryInfo)
        {
            System.Windows.Forms.TreeNode directoryNode = new System.Windows.Forms.TreeNode(directoryInfo.Name);

            foreach (System.IO.DirectoryInfo directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));

            foreach (System.IO.FileInfo file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new System.Windows.Forms.TreeNode(file.Name));

            return directoryNode;
        }
    }
}
