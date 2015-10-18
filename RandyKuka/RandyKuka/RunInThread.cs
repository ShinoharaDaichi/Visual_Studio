using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace be_isib_kuka
{
    class runInThread
    {
        public delegate void function();
        private Thread funcThread;

        //Cette classe à été créée pour ne pas être une fonction de la classe UserInterface
        //Elle est utilisée pour lancer dans un thread une fonction qui ajoutera
        //des mouvements à la pile, on lui passera donc en paramètre des nom de fonction
        //de dessin, présentes dans UserInterface

        //Le lancement d'une fonction de dessin dans un thread est faite
        //pour pouvoir :  bloquer l'ajout de points, ou encore éviter de "geler"
        //la fenêtre

        public runInThread(function f)
        {
            this.funcThread = new Thread(new ThreadStart(f));
            this.funcThread.Priority = ThreadPriority.Normal;
            this.funcThread.Start();
        }

        //pour récupérer une référence sur l'objet Thread
        public Thread getThread()
        {
            return funcThread;
        }

    }
}
