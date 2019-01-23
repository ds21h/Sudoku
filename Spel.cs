using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Spel : Form
    {
        private const int cMarge = 1;

        private Panel[] mBoxen;
        private int[] mHighLight = new int[Sudoku.AantalCellen];
        private const int cHighNorm = 0;
        private const int cHighFout = 1;
        private int[] mAchterGrond = new int[Sudoku.AantalCellen];
        private const int cAchterNorm = 0;
        private const int cAchterSel = 1;
        private int mFoutCel;
        private int mFoutWaarde;

        private Panel[] mCijfers;

        private Sudoku mSudoku;

        private int mKeuze;
        private int mKeuzeCijfer;
        private bool mOpzetten = false;
        private bool mPotlood = false;
        private bool mVol = false;

        private int mStartBoven;
        private int mStartLinks;
        private int mStartGrootte;

        public Spel()
        {
            InitializeComponent();
            mFoutCel = -1;
            mFoutWaarde = -1;
            mSudoku = new Sudoku();
            mStartBoven = txtCijfer.Top;
            mStartLinks = txtCijfer.Left;
            if (txtCijfer.Width > txtCijfer.Height)
            {
                mStartGrootte = txtCijfer.Width;
            }
            else
            {
                mStartGrootte = txtCijfer.Height;
            }
            mKeuze = 0;
            mKeuzeCijfer = 0;
            sZetKeuze();
            sDefinieerScherm();
        }

        private void sInitHighLight()
        {
            int lTeller;

            for (lTeller = 0; lTeller < Sudoku.AantalCellen; lTeller++)
            {
                mHighLight[lTeller] = cHighNorm;
            }
        }

        private void sDefinieerScherm()
        {
            int lLinks;
            int lBoven;
            int lRij;
            int lKolom;
            Panel lPanel;
            int lTeller;

            lBoven = mStartBoven;
            lTeller = 0;
            mBoxen = new Panel[Sudoku.AantalCellen];
            for (lRij = 0; lRij < 9; lRij++)
            {
                lLinks = mStartLinks;
                for (lKolom = 0; lKolom < 9; lKolom++)
                {
                    lPanel = new Panel
                    {
                        Left = lLinks,
                        Top = lBoven,
                        Height = mStartGrootte,
                        Width = mStartGrootte,
                        Tag = lTeller
                    };
                    lPanel.Click += new EventHandler(pnlCel_Click);
                    lPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCel_Paint);
                    this.Controls.Add(lPanel);
                    mBoxen[lTeller] = lPanel;
                    lTeller++;
                    lLinks = lLinks + mStartGrootte + (2 * cMarge) + 1;
                }
                lBoven = lBoven + mStartGrootte + (2 * cMarge) + 1;
            }
            mBoxen[0].BringToFront();

            mCijfers = new Panel[9];
            lLinks = mStartLinks;
            lBoven += mStartGrootte;
            for (lKolom = 0; lKolom < 9; lKolom++)
            {
                lPanel = new Panel
                {
                    Left = lLinks,
                    Top = lBoven,
                    Height = mStartGrootte,
                    Width = mStartGrootte,
                    Tag = lKolom + 1
                };
 //               lPanel.Click += new EventHandler(pnlCel_Click);
                lPanel.Paint += new System.Windows.Forms.PaintEventHandler(pnlCijfer_Paint);
                this.Controls.Add(lPanel);
                mCijfers[lKolom] = lPanel;
                lLinks = lLinks + mStartGrootte + (2 * cMarge) + 1;
            }
        }

        private void Spel_Paint(object sender, PaintEventArgs e)
        {
            Pen lPen;
            int lBegin;
            int lKol1;
            int lKol2;
            int lEind;
            int lBoven;
            int lRij1;
            int lRij2;
            int lOnder;

            lBegin = mStartLinks;
            lBoven = mStartBoven;
            lEind = lBegin + (9 * mStartGrootte) + (16 * cMarge) + 7;
            lOnder = lBoven + (9 * mStartGrootte) + (16 * cMarge) + 7;
            lRij1 = lBoven + (3 * mStartGrootte) + (5 * cMarge) + 2;
            lRij2 = lBoven + (6 * mStartGrootte) + (11 * cMarge) + 5;
            lKol1 = lBegin + (3 * mStartGrootte) + (5 * cMarge) + 2;
            lKol2 = lBegin + (6 * mStartGrootte) + (11 * cMarge) + 5;

            lPen = new Pen(Color.FromArgb(255, 0, 0, 0), 3);
            e.Graphics.DrawLine(lPen, lBegin, lRij1, lEind, lRij1);
            e.Graphics.DrawLine(lPen, lBegin, lRij2, lEind, lRij2);
            e.Graphics.DrawLine(lPen, lKol1, lBoven, lKol1, lOnder);
            e.Graphics.DrawLine(lPen, lKol2, lBoven, lKol2, lOnder);
            lPen.Dispose();
        }

        private void btnLosOp_Click(object sender, EventArgs e)
        {
            mFoutCel = -1;
            sInitHighLight();
            mSudoku.xLosOp();
            sHerschrijf();
            txtCijfer.Focus();
        }

        private void pnlCijfer_Paint(object sender, PaintEventArgs e)
        {
            Panel lPanel;
            int lCijfer;
            SolidBrush lBrush;
            Font lFont;
            int[] lTellingen;
            int lTelling;

            lPanel = (Panel)sender;
            lCijfer = (int)lPanel.Tag;

            lTellingen = mSudoku.xTelCijfers();
            lTelling = lTellingen[lCijfer];

            if (lTelling < 9)
            {
                lPanel.BackColor = Color.White;
            }
            else
            {
                lPanel.BackColor = Color.LightGray;
            }

            lBrush = new SolidBrush(Color.Black);
            lFont = txtCijfer.Font;
            e.Graphics.DrawString(lCijfer.ToString(), lFont, lBrush, 4.0F, 4.0F);

            lFont = txtPotlood.Font;
            e.Graphics.DrawString(lTelling.ToString(), lFont, lBrush, lPanel.Width * 0.75F, 4.0F);
        }

        private void pnlCel_Paint(object sender, PaintEventArgs e)
        {
            Panel lPanel;
            int lIndex;
            int lCelWaarde;

            lPanel = (Panel)sender;
            lIndex = (int)lPanel.Tag;
            sPnlCel_PaintAchtergrond(lPanel);
            sPnlCel_PaintHighlight(lPanel, e.Graphics);
            if (lIndex == mFoutCel)
            {
                lCelWaarde = mFoutWaarde;
            } else
            {
                lCelWaarde = mSudoku.xCelWaarde(lIndex);
            }
            if (lCelWaarde > 0)
            {
                sPnlCel_PaintVoorgrond(lPanel, e.Graphics, lCelWaarde);
            } else
            {
                sPnlCel_PaintPotlood(lPanel, e.Graphics);
            }
        }

        private void sPnlCel_PaintAchtergrond(Panel pPanel)
        {
            int lIndex;
            bool lKeuze;
            int[] lCelWaarden;

            lIndex = (int)pPanel.Tag;
            if (mKeuzeCijfer > 0)
            {
                if (mSudoku.xCelWaarde(lIndex) > 0)
                {
                    if (mSudoku.xCelWaarde(lIndex) == mKeuzeCijfer)
                    {
                        lKeuze = true;
                    } else
                    {
                        lKeuze = false;
                    }
                } else
                {
                    lCelWaarden = mSudoku.xCelWaarden(lIndex);
                    if (lCelWaarden[mKeuzeCijfer] > 0)
                    {
                        lKeuze = true;
                    } else
                    {
                        lKeuze = false;
                    }
                }
            } else
            {
                lKeuze = false;
            }
            if (mAchterGrond[lIndex] == cAchterNorm)
            {
                if (lKeuze)
                {
                    pPanel.BackColor = Color.PowderBlue;
                }
                else
                {
                    pPanel.BackColor = Color.White;
                }
            }
            else
            {
                if (lKeuze)
                {
                    pPanel.BackColor = Color.PowderBlue;
                }
                else
                {
                    pPanel.BackColor = Color.PapayaWhip;
                }
            }
        }

        private void sPnlCel_PaintHighlight(Panel pPanel, Graphics pGraphics)
        {
            int lIndex;
            Color lPenKleur;
            int lPenBreedte;
            Pen lPen;

            lIndex = (int)pPanel.Tag;
            if (lIndex == mKeuze)
            {
                if (mHighLight[lIndex] == cHighNorm)
                {
                    lPenKleur = Color.Black;
                    lPenBreedte = 1;
                }
                else
                {
                    lPenKleur = Color.Red;
                    lPenBreedte = 2;
                }
                lPen = new Pen(lPenKleur, lPenBreedte);
                pGraphics.DrawRectangle(lPen, lPenBreedte / 2, lPenBreedte / 2, pPanel.Width - lPenBreedte, pPanel.Height - lPenBreedte);

            }
            else
            {
                if (mHighLight[lIndex] == cHighFout)
                {
                    lPenKleur = Color.Red;
                    lPenBreedte = 1;
                    lPen = new Pen(lPenKleur, lPenBreedte);
                    pGraphics.DrawRectangle(lPen, lPenBreedte / 2, lPenBreedte / 2, pPanel.Width - lPenBreedte, pPanel.Height - lPenBreedte);
                }
            }
        }

        private void sPnlCel_PaintVoorgrond(Panel pPanel, Graphics pGraphics, int pWaarde)
        {
            int lIndex;
            SolidBrush lBrush;
            Font lFont;

            lIndex = (int)pPanel.Tag;
            if (lIndex == mFoutCel)
            {
                lBrush = new SolidBrush(Color.Red);
            }
            else
            {
                if (pWaarde == mKeuzeCijfer)
                {
                    lBrush = new SolidBrush(Color.Blue);
                }
                else
                {
                    lBrush = new SolidBrush(Color.Black);
                }
            }
            if (mSudoku.xGegeven(lIndex))
            {
                lFont = new Font(txtCijfer.Font, FontStyle.Bold);
            } else
            {
                lFont = txtCijfer.Font;
            }
            pGraphics.DrawString(pWaarde.ToString() , lFont, lBrush, 4.0F, 4.0F);
        }

        private void sPnlCel_PaintPotlood(Panel pPanel, Graphics pGraphics)
        {
            string lTekst;
            int lIndex;
            Font lFont;
            SolidBrush lBrush;
            int lTeller;
            int lTel2;
            Single lLinks;
            Single lBoven;
            Single lStap;
            int[] lCelWaarden;

            lIndex = (int)pPanel.Tag;
            lFont = txtPotlood.Font;
            lCelWaarden = mSudoku.xCelWaarden(lIndex);
            if (mKeuzeCijfer > 0)
            {
                if (lCelWaarden[mKeuzeCijfer] > 0)
                {
                    lBrush = new SolidBrush(Color.Blue);
                }
                else
                {
                    lBrush = new SolidBrush(Color.Black);
                }
            }
            else
            {
                lBrush = new SolidBrush(Color.Black);
            }
            lLinks = 2F;
            lBoven = 2F;
            lStap = pPanel.Width / 3F;
            lTel2 = 0;
            for (lTeller = 1; lTeller < lCelWaarden.Length; lTeller++)
            {
                lTekst = lCelWaarden[lTeller].ToString();
                if (lTekst != "0")
                {
                    pGraphics.DrawString(lTekst, lFont, lBrush, lLinks, lBoven);
                }
                lTel2++;
                if (lTel2 < 3)
                {
                    lLinks += lStap;
                }
                else
                {
                    lTel2 = 0;
                    lLinks = 2F;
                    lBoven += lStap;
                }
            }
        }

        private void pnlCel_Click(object sender, EventArgs e)
        {
            Panel lPanel;
 
            lPanel = (Panel)sender;
            mKeuze = (int)lPanel.Tag;
            sZetKeuze();
            txtCijfer.Focus();
            sHerschrijf();
        }

        private void txtCijfer_KeyPress(object sender, KeyPressEventArgs e)
        {
            int lIn;
            int lResult;

            if (e.KeyChar == '0' || e.KeyChar == '\b')
            {
                lIn = 0;
            }
            else
            {
                if (e.KeyChar >= '1' && e.KeyChar <= '9')
                {
                    lIn = e.KeyChar - '0';
                }
                else
                {
                    lIn = -1;
                }
            }
            if (lIn >= 0)
            {
                if (mPotlood)
                {
                    mSudoku.xFlipCelWaarde(mKeuze, lIn);
                    mKeuzeCijfer = 0;
                } else
                {
                    lResult = mSudoku.xZetCel(mKeuze, lIn, mOpzetten);
                    if (lResult == Sudoku.ResultGoed || lResult == Sudoku.ResultGoedVol)
                    {
                        sZetKeuze();
                    }
                    else
                    {
                        mKeuzeCijfer = 0;
                        mFoutCel = mKeuze;
                        mFoutWaarde = lIn;
                        mHighLight[mKeuze] = cHighFout;
                        sHighLightFout();
                    }
                }

                sHerschrijf();
            }
            e.Handled = true;
        }

        private void sZetKeuze()
        {
            int lTeller;
            int[] lGroep;

            mKeuzeCijfer = mSudoku.xCelWaarde(mKeuze);
            for (lTeller = 0; lTeller < mAchterGrond.Length; lTeller++)
            {
                mAchterGrond[lTeller] = cAchterNorm;
            }
            lGroep = mSudoku.xRij(mKeuze);
            for (lTeller = 0; lTeller < lGroep.Length; lTeller++)
            {
                mAchterGrond[lGroep[lTeller]] = cAchterSel;
            }
            lGroep = mSudoku.xKolom(mKeuze);
            for (lTeller = 0; lTeller < lGroep.Length; lTeller++)
            {
                mAchterGrond[lGroep[lTeller]] = cAchterSel;
            }
            lGroep = mSudoku.xSegment(mKeuze);
            for (lTeller = 0; lTeller < lGroep.Length; lTeller++)
            {
                mAchterGrond[lGroep[lTeller]] = cAchterSel;
            }
            mFoutCel = -1;
            sInitHighLight();
        }

        private void sHighLightFout()
        {
            int lTeller;
            int[] lFouteCellen;

            lFouteCellen = mSudoku.xFouteCellen();
            for (lTeller = 0; lTeller < lFouteCellen.Length; lTeller++)
            {
                mHighLight[lFouteCellen[lTeller]] = cHighFout;
            }
        }

        private void txtCijfer_KeyDown(object sender, KeyEventArgs e)
        {
            int lVolgNummer;
            bool lVerwerkt;

            lVolgNummer = mKeuze;
            switch (e.KeyCode)
            {
                case Keys.Down:
                    lVolgNummer += 9;
                    if (lVolgNummer >= Sudoku.AantalCellen )
                    {
                        lVolgNummer -= Sudoku.AantalCellen;
                    }
                    lVerwerkt = true;
                    break;
                case Keys.Up:
                    lVolgNummer -= 9;
                    if (lVolgNummer < 0)
                    {
                        lVolgNummer += Sudoku.AantalCellen;
                    }
                    lVerwerkt = true;
                    break;
                case Keys.Left:
                    if (lVolgNummer % 9 == 0)
                    {
                        lVolgNummer += 8;
                    }
                    else
                    {
                        lVolgNummer -= 1;
                    }
                    lVerwerkt = true;
                    break;
                case Keys.Right:
                    if (lVolgNummer % 9 == 8)
                    {
                        lVolgNummer -= 8;
                    }
                    else
                    {
                        lVolgNummer += 1;
                    }
                    lVerwerkt = true;
                    break;
                default:
                    lVerwerkt = false;
                    break;
            }
            if (lVerwerkt)
            {
                mKeuze = lVolgNummer;
                sZetKeuze();
                sHerschrijf();
                e.Handled = true;
            }
        }

        private void sHerschrijf()
        {
            int lTeller;

            for (lTeller = 0; lTeller < Sudoku.AantalCellen; lTeller++)
            {
                mBoxen[lTeller].Invalidate();
            }
            for (lTeller = 0; lTeller < mCijfers.Length; lTeller++)
            {
                mCijfers[lTeller].Invalidate();
            }
        }

        private void btnOpzetten_Click(object sender, EventArgs e)
        {
            if (mOpzetten)
            {
                mOpzetten = false;
                btnOpzetten.Text = "Opzetten";
                btnLosOp.Enabled = true;
            } else
            {
                mOpzetten = true;
                btnOpzetten.Text = "Klaar";
                btnLosOp.Enabled = false;
            }
            txtCijfer.Focus();
        }

        private void btnNieuw_Click(object sender, EventArgs e)
        {
            mFoutCel = -1;
            sInitHighLight();
            mSudoku.xNieuw();
            sHerschrijf();
            txtCijfer.Focus();
        }

        private void btnPotlood_Click(object sender, EventArgs e)
        {
            mPotlood = !mPotlood;
            btnPotloodInvullen.Enabled = mPotlood;
            btnPotloodWis.Enabled = mPotlood;
            sHerschrijf();
            txtCijfer.Focus();
        }

        private void btnPotloodInvullen_Click(object sender, EventArgs e)
        {
            mSudoku.xZetCelWaarden();
            sHerschrijf();
            txtCijfer.Focus();
        }

        private void btnPotloodWis_Click(object sender, EventArgs e)
        {
            mSudoku.xWisCelWaarden();
            sHerschrijf();
            txtCijfer.Focus();
        }

        private void btnGenereer_Click(object sender, EventArgs e)
        {
            mSudoku.xGenereer(40);
            sHerschrijf();
            txtCijfer.Focus();
        }
    }
}
