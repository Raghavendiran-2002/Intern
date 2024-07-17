# Deploying a Static Site in Docker on Azure VM (Ubuntu) using Azure CLI

To deploy a static site in Docker on an Azure VM running Ubuntu created using Azure CLI, follow these steps:

1. **Create an Azure VM using Azure CLI:**

   ```bash
   az vm create --resource-group rg_raghav --name myVM --image UbuntuLTS --admin-username azureuser --generate-ssh-keys
   ```

2. **SSH into the Azure VM:**

   ```bash
   ssh azureuser@<public-ip-address>
   ```

3. **Install Docker on the Azure VM:**

   ```bash
   sudo apt update
   sudo apt install -y apt-transport-https ca-certificates curl software-properties-common
   curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add -
   sudo add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/ubuntu $(lsb_release -cs) stable"
   sudo apt update
   sudo apt install -y docker-ce
   ```

4. **Prepare your Static Site:**

   - Place your static site files (HTML, CSS, JS) in a directory on the VM.

5. **Clone the github repo:**

   ```
   git clone <repo-url>
   cd /Intern/15-July-24/
   ```

6. **Build and Run the Docker Image:**

   ```bash
   docker build -t wordle-site .
   docker run -d -p 80:80 wordle-site
   ```

7. **Access Your Static Site:**

   - Access your static site using the public IP of your Azure VM.

8. **Optional: Set up a Domain Name:**

   - If desired, configure a domain name to point to your Azure VM's public IP.

9. **Monitor and Manage the Docker Container:**

   - Use Docker commands to monitor and manage your running container.

10. **Cleanup:**
    - When done, clean up resources to avoid unnecessary charges.
    ```
        az group delete --name "rg_raghav"
    ```

These steps will help you deploy your static site in Docker on an Azure VM created using Azure CLI.
