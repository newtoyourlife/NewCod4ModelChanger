using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace NewCod4ModelChanger
{
    public partial class Cod4ModelChanger : Form



        {
        public Cod4ModelChanger()
        {
 
        InitializeComponent();
            
    }
        public class MyClass
        {
            public string Team;
            public string Head;
            public string Body;
            public string PreHead;
            public string PreBody;
            public string ModFolderPath;
            public string txtModFolder;

        }
        MyClass a = new MyClass();
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void ChangedModelNameUpadte()
        {
            lblHeadAfter.Text = a.Head;
            lblBodyAfter.Text = a.Body;
        }

        public string CustomModelImport(string ModelName)
        {
            a.txtModFolder = txtModFolder.Text;

            string Cod4Xmodelpath = txtCod4FolderPath.Text;
            string tagorigin_loc = Cod4Xmodelpath + "\\tag_origin";

            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string importxmodel = RunningPath+ "\\models\\custom models\\"+ ModelName;
            string importxmodelpath = importxmodel + "\\xmodel\\";

            string destinationlocation = a.txtModFolder;
            string destinationFilePathBody = importxmodelpath + a.PreBody;
            string destinationFilePathHead = destinationlocation + "\\xmodel\\" + a.PreHead;

            string xmodelfilename = Directory.EnumerateFiles(importxmodelpath).FirstOrDefault();
            if (!string.IsNullOrEmpty(xmodelfilename))
            {
                File.Move(xmodelfilename, destinationFilePathBody);
            }

            foreach (string dirPath in Directory.GetDirectories(importxmodel, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(importxmodel, destinationlocation));
            }

            foreach (string newPath in Directory.GetFiles(importxmodel, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(importxmodel, destinationlocation), true);
            }

            if (File.Exists(destinationFilePathHead))
            {
                File.Delete(destinationFilePathHead);
            }
            File.Copy(tagorigin_loc, destinationFilePathHead);

            string csvfilePath = a.txtModFolder + "\\mod.csv";
            string valueToAdd1 = $"xmodel,{a.PreBody}";


            //body
            List<string> csvContent = File.ReadAllLines(csvfilePath).ToList();
            if (!csvContent.Contains(valueToAdd1))
            {
                csvContent.Add(valueToAdd1);
                File.WriteAllLines(csvfilePath, csvContent);
            }

            //HEAD
            string valueToAdd2 = $"xmodel,{a.PreHead}";

            List<string> csvContent1 = File.ReadAllLines(csvfilePath).ToList();
            if (!csvContent1.Contains(valueToAdd2))
            {
                csvContent1.Add(valueToAdd2);
                File.WriteAllLines(csvfilePath, csvContent1);
            }

            return valueToAdd2;
        }

        private void Cod4ModelChanger_Load(object sender, EventArgs e)
        {
            a.Team = "OpFor";
            a.PreHead = "No Head Selected";
            a.PreBody = "No Body Selected";
            btnTeamARAB.BackColor = Color.LightGreen;


            if (File.Exists(@"Cod4Path.txt"))
            {
                txtCod4FolderPath.Text = File.ReadAllText(@"Cod4Path.txt");
            }
        
            if (File.Exists(@"ModFolder.txt"))
            {
                txtModFolder.Text = File.ReadAllText(@"ModFolder.txt");
            }

            a.txtModFolder = txtModFolder.Text;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            gbBodyViewer.Visible = true;
            gbSelection.Visible = false;
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = true;
            gbSelection.Visible = false;
        }

        private void body_mp_opforce_support_Click(object sender, EventArgs e)
        {
            gbBodyViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_opforce_support;
            a.Body = "body_mp_opforce_support";
        }

        private void body_mp_arab_regular_support_Click(object sender, EventArgs e)
        {
            gbBodyViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_support;
            a.Body = "body_mp_arab_regular_support";
        }

        private void btnTeamARAB_Click(object sender, EventArgs e)
        {
            a.Team = "OpFor";
            btnTeamARAB.BackColor = Color.LightGreen;
            button16.BackColor = Color.White;
            button14.BackColor = Color.White;
            button3.BackColor = Color.White;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            button12.BackColor = Color.White;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //WIP!!!!
            String body = "body_mp_arab_regular_sniper";
            string directoryPath = a.txtModFolder + "\\xmodel\\";
            string fullPath = Path.Combine(directoryPath, body);
            if (a.Team == "OpFor")
            {
                if (File.Exists(fullPath))
                {
                    picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_sniper;
                    picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_sadiq;
                    a.PreBody = "body_mp_arab_regular_sniper";
                    a.PreHead = "head_mp_arab_regular_sadiq";
                    lblHeadBefore.Text = a.PreHead;
                }
                else
                {
                    picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_sniper;
                    picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_sadiq;
                    a.PreBody = "body_mp_arab_regular_sniper";
                    a.PreHead = "head_mp_arab_regular_sadiq";
                }
            }    
            if(a.Team == "USMC")
            {
                picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_sniper;
                picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_tactical_baseball_cap;
                a.PreBody = "body_mp_usmc_sniper";
                a.PreHead = "head_mp_usmc_tactical_baseball_cap";
                
            }
            lblHeadBefore.Text = a.PreHead;
            lblBodyBefore.Text = a.PreBody;
            button3.BackColor = Color.FromArgb(194, 255, 189);
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            button12.BackColor = Color.White;
            button15.BackColor = Color.White;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
            string custommodelpath = RunningPath + "\\models\\custom models\\";

            string[] folderPaths = Directory.GetDirectories(custommodelpath);
            string[] folderNames = new string[folderPaths.Length];

            for (int i = 0; i < folderPaths.Length; i++)
            {
                folderNames[i] = Path.GetFileName(folderPaths[i]);
            }


            if (!(folderNames.Contains(a.Body)))
            {
                a.txtModFolder = txtModFolder.Text;
                string sourceDirPath = txtCod4FolderPath.Text;
                string sourceFilePathBody = Path.Combine(sourceDirPath, a.Body);
                string sourceFilePathHead = Path.Combine(sourceDirPath, a.Head);

                string destinationDirPath = a.txtModFolder + "\\xmodel\\";
                string destinationFilePathBody = Path.Combine(destinationDirPath, a.PreBody);

                string destinationFilePathHead = Path.Combine(destinationDirPath, a.PreHead);

                Console.Write(destinationFilePathBody);
                File.Copy(sourceFilePathBody, destinationFilePathBody, true);
                File.Copy(sourceFilePathHead, destinationFilePathHead, true);

                //MOD CSV STUFF



                string csvfilePath = a.txtModFolder + "\\mod.csv";
                string valueToAdd1 = $"xmodel,{a.PreBody}";


                //body
                List<string> csvContent = File.ReadAllLines(csvfilePath).ToList();
                if (!csvContent.Contains(valueToAdd1))
                {
                    csvContent.Add(valueToAdd1);
                    File.WriteAllLines(csvfilePath, csvContent);
                }

                //HEAD
                string valueToAdd2 = $"xmodel,{a.PreHead}";

                List<string> csvContent1 = File.ReadAllLines(csvfilePath).ToList();
                if (!csvContent1.Contains(valueToAdd2))
                {
                    csvContent1.Add(valueToAdd2);
                    File.WriteAllLines(csvfilePath, csvContent1);
                }
            }
            else
            {
                string modelname = a.Body;
                string complete = CustomModelImport(modelname);
                txtStatus.Text = a.PreBody+" Has been updated to "+a.Body;

            }

            



        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            gbBodyViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_opforce_sniper;
            a.Body = "body_mp_opforce_support";
            ChangedModelNameUpadte();

        }

        private void body_mp_opforce_assault_Click(object sender, EventArgs e)
        {
            gbBodyViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_opforce_assault;
            a.Body = "body_mp_opforce_assault";
            ChangedModelNameUpadte();
        }

        private void body_mp_opforce_sniper_urban_Click(object sender, EventArgs e)
        {
            gbBodyViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_opforce_sniper_urban;
            a.Body = "body_mp_opforce_sniper_urban";
            ChangedModelNameUpadte();
        }

        private void body_mp_arab_regular_sniper_Click(object sender, EventArgs e)
        {
            gbBodyViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_sniper;
            a.Body = "body_mp_arab_regular_sniper";
            ChangedModelNameUpadte();
        }

        private void body_mp_arab_regular_cqb_Click(object sender, EventArgs e)
        {
            gbBodyViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_cqb;
            a.Body = "body_mp_arab_regular_cqb";
            ChangedModelNameUpadte();
        }

        private void body_mp_arab_regular_assault_Click(object sender, EventArgs e)
        {
            gbBodyViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_assault;
            a.Body = "body_mp_arab_regular_assault";
            ChangedModelNameUpadte();
        }

        private void body_mp_opforce_cqb_Click(object sender, EventArgs e)
        {
            gbBodyViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_opforce_cqb;
            a.Body = "body_mp_opforce_cqb";
            ChangedModelNameUpadte();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gbBodyViewer.Visible = false;
            gbBodyViewer1.Visible = true;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            gbBodyViewer.Visible = true;
            gbBodyViewer1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gbBodyViewer1.Visible = false;
            gbBodyViewer2.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gbBodyViewer1.Visible = true;
            gbBodyViewer2.Visible = false;
        }

        private void body_mp_usmc_woodland_sniper_Click(object sender, EventArgs e)
        {
            gbBodyViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_woodland_sniper;
            a.Body = "body_mp_usmc_woodland_sniper";
            ChangedModelNameUpadte();
        }

        private void body_mp_usmc_woodland_support_Click(object sender, EventArgs e)
        {
            gbBodyViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_woodland_support;
            a.Body = "body_mp_usmc_woodland_support";
            ChangedModelNameUpadte();
        }

        private void head_mp_usmc_tactical_mich_stripes_nomex_Click(object sender, EventArgs e)
        {
            gbBodyViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_woodland_specops;
            a.Body = "body_mp_usmc_woodland_specops";
            ChangedModelNameUpadte();
        }

        private void body_mp_sas_urban_assault_Click(object sender, EventArgs e)
        {
            gbBodyViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_sas_urban_assault;
            a.Body = "body_mp_sas_urban_assault";
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            a.Head = "tag_origin";
            ChangedModelNameUpadte();
        }

        private void body_mp_sas_urban_recon_Click(object sender, EventArgs e)
        {
            gbBodyViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_sas_urban_recon;
            a.Body = "body_mp_sas_urban_recon";
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            a.Head = "tag_origin";
            ChangedModelNameUpadte();
        }

        private void body_mp_sas_urban_sniper_Click(object sender, EventArgs e)
        {
            gbBodyViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_sas_urban_sniper;
            a.Body = "body_mp_sas_urban_sniper";
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            a.Head = "tag_origin";
            ChangedModelNameUpadte();
        }

        private void body_mp_sas_urban_specops_Click(object sender, EventArgs e)
        {
            gbBodyViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_sas_urban_specops;
            a.Body = "body_mp_sas_urban_specops";
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            a.Head = "tag_origin";
            ChangedModelNameUpadte();
        }

        private void body_mp_sas_urban_support_Click(object sender, EventArgs e)
        {
            gbBodyViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_sas_urban_support;
            a.Body = "body_mp_sas_urban_support";
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            a.Head = "tag_origin";
            ChangedModelNameUpadte();
        }

        private void body_mp_usmc_assault_Click(object sender, EventArgs e)
        {
            gbBodyViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_assault;
            a.Body = "body_mp_usmc_assault";
            ChangedModelNameUpadte();
        }

        private void body_mp_usmc_cqb_Click(object sender, EventArgs e)
        {
            gbBodyViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_cqb;
            a.Body = "body_mp_usmc_cqb";
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            a.Head = "tag_origin";
            ChangedModelNameUpadte();
        }

        private void body_mp_usmc_recon_Click(object sender, EventArgs e)
        {
            gbBodyViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_recon;
            a.Body = "body_mp_usmc_recon";
            ChangedModelNameUpadte();
        }

        private void body_mp_usmc_rifleman_Click(object sender, EventArgs e)
        {
            gbBodyViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_rifleman;
            a.Body = "body_mp_usmc_rifleman";
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            a.Head = "tag_origin";
            ChangedModelNameUpadte();
        }

        private void body_mp_usmc_sniper_Click(object sender, EventArgs e)
        {
            gbBodyViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_sniper;
            a.Body = "body_mp_usmc_sniper";
            ChangedModelNameUpadte();
        }

        private void body_mp_usmc_specops_Click(object sender, EventArgs e)
        {
            gbBodyViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_specops;
            a.Body = "body_mp_usmc_specops";
            ChangedModelNameUpadte();
        }

        private void body_mp_usmc_support_Click(object sender, EventArgs e)
        {
            gbBodyViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_support;
            a.Body = "body_mp_usmc_support";
            ChangedModelNameUpadte();
        }

        private void body_mp_usmc_woodland_assault_Click(object sender, EventArgs e)
        {
            gbBodyViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_woodland_assault;
            a.Body = "body_mp_usmc_woodland_assault";
            ChangedModelNameUpadte();
        }

        private void body_mp_usmc_woodland_recon_Click(object sender, EventArgs e)
        {
            gbBodyViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_woodland_recon;
            a.Body = "body_mp_usmc_woodland_recon";
            ChangedModelNameUpadte();
        }

        private void tag_orgin_Click(object sender, EventArgs e)
        {
            gbHeadViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            a.Head = "tag_origin";
            ChangedModelNameUpadte();
        }

        private void head_mp_usmc_tactical_mich_stripes_nomex_Click_1(object sender, EventArgs e)
        {
            gbHeadViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_tactical_mich_stripes_nomex;
            a.Head = "head_mp_usmc_tactical_mich_stripes_nomex";
            ChangedModelNameUpadte();
        }

        private void head_mp_usmc_tactical_mich_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_tactical_mich;
            a.Head = "head_mp_usmc_tactical_mich";
            ChangedModelNameUpadte();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbHeadViewer1.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbHeadViewer2.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbHeadViewer.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            gbHeadViewer2.Visible = false;
            gbHeadViewer1.Visible = true;
        }

        private void head_mp_usmc_pasdgt_covered_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_pasdgt_covered;
            a.Head = "head_mp_usmc_pasdgt_covered";
        }

        private void head_mp_usmc_tactical_baseball_cap_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_tactical_baseball_cap;
            a.Head = "head_mp_usmc_tactical_baseball_cap";
        }

        private void head_mp_usmc_shaved_head_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_shaved_head;
            a.Head = "head_mp_usmc_shaved_head";
        }

        private void head_mp_usmc_nomex_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_nomex;
            a.Head = "head_mp_usmc_nomex";
        }

        private void head_mp_usmc_ghillie_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_ghillie;
            a.Head = "head_mp_usmc_ghillie";
        }

        private void head_mp_opforce_ski_mask_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_ski_mask;
            a.Head = "head_mp_opforce_ski_mask";
        }

        private void head_mp_opforce_justin_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_justin;
            a.Head = "head_mp_opforce_justin";

        }

        private void head_mp_opforce_headwrap_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_headwrap;
            a.Head = "head_mp_opforce_headwrap";
        }

        private void head_mp_arab_regular_asad_Click(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_asad;
            a.Head = "head_mp_arab_regular_asad";
        }

        private void head_mp_arab_regular_headwrap_Click(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_headwrap;
            a.Head = "head_mp_arab_regular_headwrap";
        }

        private void head_mp_arab_regular_sadiq_Click(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_sadiq;
            a.Head = "head_mp_arab_regular_sadiq";

        }

        private void head_mp_arab_regular_ski_mask_Click_1(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_ski_mask;
            a.Head = "head_mp_arab_regular_ski_mask";
        }

        private void head_mp_arab_regular_suren_Click(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_suren;
            a.Head = "head_mp_arab_regular_suren";
        }

        private void head_mp_opforce_3hole_mask_Click(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_3hole_mask;
            a.Head = "head_mp_opforce_3hole_mask";
        }

        private void head_mp_opforce_david_Click(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_david;
            a.Head = "head_mp_opforce_david";
        }

        private void head_mp_opforce_gasmask_Click(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_gasmask;
            a.Head = "head_mp_opforce_gasmask";
        }

        private void head_mp_opforce_ghillie_Click(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_ghillie;
            a.Head = "head_mp_opforce_ghillie";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (a.Team == "OpFor")
            {
                picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_assault;
                picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_suren;
                a.PreBody = "body_mp_arab_regular_assault";
                a.PreHead = "head_mp_arab_regular_suren";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (a.Team == "OpFor")
            {
                picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_support;
                picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_ski_mask;
                a.PreBody = "body_mp_arab_regular_support";
                a.PreHead = "head_mp_arab_regular_ski_mask";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (a.Team == "OpFor")
            {
                picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_cqb;
                picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_headwrap;
                a.PreBody = "body_mp_arab_regular_cqb";
                a.PreHead = "head_mp_arab_regular_headwrap";

            }
        }

        private void Cod4ModelChanger_Load_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }


        private void head_mp_arab_regular_asad_Click_1(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_asad;
            a.Head = "head_mp_arab_regular_asad";
            ChangedModelNameUpadte();
        }

        private void head_mp_arab_regular_headwrap_Click_1(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_headwrap;
            a.Head = "head_mp_arab_regular_headwrap";
            ChangedModelNameUpadte();
        }

        private void head_mp_arab_regular_sadiq_Click_1(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_sadiq;
            a.Head = "head_mp_arab_regular_sadiq";
            ChangedModelNameUpadte();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_ski_mask;
            a.Head = "head_mp_arab_regular_ski_mask";
            ChangedModelNameUpadte();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_suren;
            a.Head = "head_mp_arab_regular_suren";
            ChangedModelNameUpadte();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_3hole_mask;
            a.Head = "head_mp_opforce_3hole_mask";
            ChangedModelNameUpadte();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_david;
            a.Head = "head_mp_opforce_david";
            ChangedModelNameUpadte();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_gasmask;
            a.Head = "head_mp_opforce_gasmask";
            ChangedModelNameUpadte();
        }

        private void pictureBox4_Click_2(object sender, EventArgs e)
        {
            gbHeadViewer.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_ghillie;
            a.Head = "head_mp_opforce_ghillie";
            ChangedModelNameUpadte();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            {
                gbHeadViewer.Visible = false;
                gbHeadViewer1.Visible = true;
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (a.Team == "OpFor")
            {
                picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_cqb;
                picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_headwrap;
                a.PreBody = "body_mp_arab_regular_cqb";
                a.PreHead = "head_mp_arab_regular_headwrap";

            }
            if (a.Team == "USMC")
            {
                picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_specops;
                picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_tactical_mich_stripes_nomex;
                a.PreBody = "body_mp_usmc_specops";
                a.PreHead = "head_mp_usmc_tactical_mich_stripes_nomex";

            }
            lblHeadBefore.Text = a.PreHead;
            lblBodyBefore.Text = a.PreBody;
            button3.BackColor = Color.White;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            button12.BackColor = Color.FromArgb(194, 255, 189);
            button15.BackColor = Color.White;
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            if (a.Team == "OpFor")
            {
                picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_engineer;
                picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_ski_mask;
                a.PreBody = "body_mp_arab_regular_engineer";
                a.PreHead = "head_mp_arab_regular_ski_mask";
            }
            if (a.Team == "USMC")
            {
                picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_recon;
                picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_nomex;
                a.PreBody = "body_mp_usmc_recon";
                a.PreHead = "head_mp_usmc_nomex";
            }
            lblHeadBefore.Text = a.PreHead;
            lblBodyBefore.Text = a.PreBody;
            button3.BackColor = Color.White;
            button10.BackColor = Color.White;
            button11.BackColor = Color.FromArgb(194, 255, 189);
            button12.BackColor = Color.White;
            button15.BackColor = Color.White;
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (a.Team == "OpFor")
            {
                picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_assault;
                picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_suren;
                a.PreBody = "body_mp_arab_regular_assault";
                a.PreHead = "head_mp_arab_regular_suren";
            }
            if (a.Team == "USMC")
            {
                picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_assault;
                picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_tactical_mich;
                a.PreBody = "body_mp_usmc_assault";
                a.PreHead = "head_mp_usmc_tactical_mich";

            }
            lblHeadBefore.Text = a.PreHead;
            lblBodyBefore.Text = a.PreBody;
            button3.BackColor = Color.White;
            button10.BackColor = Color.FromArgb(194, 255, 189);
            button11.BackColor = Color.White;
            button12.BackColor = Color.White;
            button15.BackColor = Color.White;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            gbHeadViewer2.Visible = false;
            gbHeadViewer1.Visible = true;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            gbHeadViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_tactical_mich_stripes_nomex;
            a.Head = "head_mp_usmc_tactical_mich_stripes_nomex";
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            gbHeadViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            a.Head = "tag_origin";
            ChangedModelNameUpadte();
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_headwrap;
            a.Head = "head_mp_opforce_headwrap";
            ChangedModelNameUpadte();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_justin;
            a.Head = "head_mp_opforce_justin";
            ChangedModelNameUpadte();
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_opforce_ski_mask;
            a.Head = "head_mp_opforce_ski_mask";
            ChangedModelNameUpadte();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_ghillie;
            a.Head = "head_mp_usmc_ghillie";
            ChangedModelNameUpadte();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_nomex;
            a.Head = "head_mp_usmc_nomex";
            ChangedModelNameUpadte();
        }            
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_pasdgt_covered;
            a.Head = "head_mp_usmc_pasdgt_covered";
            ChangedModelNameUpadte();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_shaved_head;
            a.Head = "head_mp_usmc_shaved_head";
            ChangedModelNameUpadte();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_tactical_baseball_cap;
            a.Head = "head_mp_usmc_tactical_baseball_cap";
            ChangedModelNameUpadte();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbSelection.Visible = true;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_tactical_mich;
            a.Head = "head_mp_usmc_tactical_mich";
            ChangedModelNameUpadte();
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbHeadViewer2.Visible = true;
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            gbHeadViewer1.Visible = false;
            gbHeadViewer.Visible = true;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void gbSelection_Enter(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            File.WriteAllText(@"Cod4Path.txt", txtCod4FolderPath.Text);
            File.WriteAllText(@"ModPath.txt", txtModFolder.Text);
            File.WriteAllText(@"ModFolder.txt", txtModFolder.Text);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            a.Team = "USMC";
            button14.BackColor = Color.LightGreen;
            button16.BackColor = Color.White;
            btnTeamARAB.BackColor = Color.White;
            button3.BackColor = Color.White;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            button12.BackColor = Color.White;
            button15.BackColor = Color.White;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (a.Team == "OpFor")
            {
                picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_support;
                picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_arab_regular_asad;
                a.PreBody = "body_mp_arab_regular_support";
                a.PreHead = "head_mp_arab_regular_asad";

            }
            if (a.Team == "USMC")
            {
                picUnchangedBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_usmc_support;
                picUnchangedHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.head_mp_usmc_shaved_head;
                a.PreBody = "body_mp_usmc_support";
                a.PreHead = "head_mp_usmc_shaved_head";

            }
            lblHeadBefore.Text = a.PreHead;
            lblBodyBefore.Text = a.PreBody;
            button3.BackColor = Color.White;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            button12.BackColor = Color.White;
            button15.BackColor = Color.FromArgb(194, 255, 189);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            a.Team = "SAS";

            button16.BackColor = Color.LightGreen;
            button14.BackColor = Color.White;
            btnTeamARAB.BackColor = Color.White;
            button3.BackColor = Color.White;
            button10.BackColor = Color.White;
            button11.BackColor = Color.White;
            button12.BackColor = Color.White;
            button15.BackColor = Color.White;
        }

        private void lblHeadBefore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(a.PreHead);
        }

        private void lblBodyBefore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(a.PreBody);
        }

        private void button17_Click(object sender, EventArgs e)
        {
 
        }

        private void gbModelImport_Enter(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            a.txtModFolder = txtModFolder.Text;
            string modcsvdelete = txtImportLocation.Text;
            string modcsvdeletepath = Path.Combine(modcsvdelete + "\\mod.csv");
            File.Delete(modcsvdeletepath);

            string destinationlocation = a.txtModFolder;
            string destinationFilePathBody = destinationlocation + "\\xmodel\\"+ a.PreBody;
            string destinationFilePathHead = destinationlocation + "\\xmodel\\" + a.PreHead;


            string Cod4Xmodelpath = txtCod4FolderPath.Text;
            string tagorigin_loc = Cod4Xmodelpath + "\\tag_origin";


            string importxmodel = txtImportLocation.Text;
            string importxmodelpath = Path.Combine(modcsvdelete + "\\xmodel\\");
            string xmodelfilename = Directory.EnumerateFiles(importxmodelpath).FirstOrDefault();
            if (!string.IsNullOrEmpty(xmodelfilename)){
                if (File.Exists(destinationFilePathBody))
                {
                    File.Delete(destinationFilePathBody);
                }
                File.Move(xmodelfilename, destinationFilePathBody);

            }

            if (File.Exists(destinationFilePathHead))
            {
                File.Delete(destinationFilePathHead);
            }
            File.Copy(tagorigin_loc, destinationFilePathHead);

            Directory.Delete(importxmodel + "\\xmodel\\", true);

            foreach (string dirPath in Directory.GetDirectories(importxmodel, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(importxmodel, destinationlocation));
            }

            foreach (string newPath in Directory.GetFiles(importxmodel, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(importxmodel, destinationlocation), true);
            }


            string csvfilePath = a.txtModFolder + "\\mod.csv";
            string valueToAdd1 = $"xmodel,{a.PreBody}";


            //body
            List<string> csvContent = File.ReadAllLines(csvfilePath).ToList();
            if (!csvContent.Contains(valueToAdd1))
            {
                csvContent.Add(valueToAdd1);
                File.WriteAllLines(csvfilePath, csvContent);
            }

            //HEAD
            string valueToAdd2 = $"xmodel,{a.PreHead}";

            List<string> csvContent1 = File.ReadAllLines(csvfilePath).ToList();
            if (!csvContent1.Contains(valueToAdd2))
            {
                csvContent1.Add(valueToAdd2);
                File.WriteAllLines(csvfilePath, csvContent1);
            }

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtModFolderPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtModFolder_TextChanged(object sender, EventArgs e)
        {

        }

        private void JohnCena_Click(object sender, EventArgs e)
        {
            gbBodyViewer2.Visible = false;
            gbSelection.Visible = true;
            a.Body = "JohnCena";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.JohnCena;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();

        }

        private void CarlJohnson_Click(object sender, EventArgs e)
        {
            gbBodyViewer3.Visible = false;
            gbSelection.Visible = true;
            a.Body = "CarlJohnson";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.CarlJohnson1;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            gbBodyViewer2.Visible = true;
            gbBodyViewer3.Visible = false;

        }

        private void button19_Click(object sender, EventArgs e)
        {
            gbBodyViewer3.Visible = true;
            gbBodyViewer2.Visible = false;
        }
        private void pictureBox20_Click(object sender, EventArgs e)
        {
            gbBodyViewer3.Visible = false;
            gbSelection.Visible = true;
            a.Body = "PoliceOfficer";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.PoliceOfficer;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            gbBodyViewer3.Visible = false;
            gbSelection.Visible = true;
            a.Body = "Lion";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.Lion;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            gbBodyViewer3.Visible = false;
            gbSelection.Visible = true;
            a.Body = "Sylvanas";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.Sylvanas;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            gbBodyViewer3.Visible = false;
            gbSelection.Visible = true;
            a.Body = "MasterChief";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.MasterChief;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void lblBodyAfter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(lblBodyAfter.Text);
        }

        private void lblHeadAfter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(lblHeadAfter.Text);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            gbBodyViewer3.Visible = false;
            gbSelection.Visible = true;
            a.Body = "Spiderman";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.Spiderman;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            gbBodyViewer3.Visible = false;
            gbSelection.Visible = true;
            a.Body = "BatGirl";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.Batgirl;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            gbBodyViewer3.Visible = false;
            gbSelection.Visible = true;
            a.Body = "CSSBadassTerr";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.CSSBadassTerr;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            gbBodyViewer3.Visible = false;
            gbSelection.Visible = true;
            a.Body = "Yuusha_1";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.Yuusha;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            gbBodyViewer4.Visible = false;
            gbSelection.Visible = true;
            a.Body = "Yuusha_2";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.Yuusha_2;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            gbBodyViewer4.Visible = false;
            gbSelection.Visible = true;
            a.Body = "Tourrette";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.Tourrette;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            gbBodyViewer4.Visible = false;
            gbSelection.Visible = true;
            a.Body = "Elysium";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.Elysium;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            gbBodyViewer3.Visible = false;
            gbBodyViewer4.Visible = true;
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            gbBodyViewer4.Visible = false;
            gbSelection.Visible = true;
            a.Body = "Eo";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.Eo;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            gbBodyViewer4.Visible = false;
            gbSelection.Visible = true;
            a.Body = "DragonWarrior";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.DragonWarrior;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            gbBodyViewer4.Visible = false;
            gbSelection.Visible = true;
            a.Body = "BigSmoke";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.BigSmoke;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            gbBodyViewer4.Visible = false;
            gbBodyViewer3.Visible = true;
        }

        private void gbBodyViewer3_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {

        }

        private void body_mp_arab_regular_engineer_Click(object sender, EventArgs e)
        {
            gbBodyViewer2.Visible = false;
            gbSelection.Visible = true;
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.body_mp_arab_regular_engineer;
            a.Body = "body_mp_arab_regular_engineer";
            ChangedModelNameUpadte();
        }

        private void JohnCena_Click_1(object sender, EventArgs e)
        {
            gbBodyViewer4.Visible = false;
            gbSelection.Visible = true;
            a.Body = "JohnCena";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.JohnCena;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            gbBodyViewer4.Visible = false;
            gbSelection.Visible = true;
            a.Body = "Gign";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.Gign;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox9_Click_1(object sender, EventArgs e)
        {
            gbBodyViewer4.Visible = false;
            gbSelection.Visible = true;
            a.Body = "ArcticAvenger";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.ArcticAvenger;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void BlackWidow_Click(object sender, EventArgs e)
        {
            gbBodyViewer5.Visible = false;
            gbSelection.Visible = true;
            a.Body = "BlackWidow";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.BlackWidow;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            gbBodyViewer5.Visible = false;
            gbSelection.Visible = true;
            a.Body = "Vaas";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.Vaas;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            gbBodyViewer5.Visible = false;
            gbSelection.Visible = true;
            a.Body = "Paladin";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.Paladin;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox29_Click_1(object sender, EventArgs e)
        {
            gbBodyViewer5.Visible = false;
            gbSelection.Visible = true;
            a.Body = "JohnMarston";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.JohnMarston;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            gbBodyViewer5.Visible = false;
            gbBodyViewer4.Visible = true;
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            gbBodyViewer5.Visible = false;
            gbSelection.Visible = true;
            a.Body = "BlackPanther";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.BlackPanther;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox28_Click_1(object sender, EventArgs e)
        {
            gbBodyViewer5.Visible = false;
            gbSelection.Visible = true;
            a.Body = "HellDemon";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.HellDemon;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox9_Click_2(object sender, EventArgs e)
        {
            gbBodyViewer5.Visible = false;
            gbSelection.Visible = true;
            a.Body = "JohnWick";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.JohnWick;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            gbBodyViewer5.Visible = false;
            gbSelection.Visible = true;
            a.Body = "RoscoLight";
            a.Head = "tag_origin";
            picChangeBody.BackgroundImage = NewCod4ModelChanger.Properties.Resources.JohnCena;
            picChangeHead.BackgroundImage = NewCod4ModelChanger.Properties.Resources.tag_orgin;
            ChangedModelNameUpadte();
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            gbBodyViewer5.Visible = true;
            gbBodyViewer4.Visible = false;
        }
    }
}
